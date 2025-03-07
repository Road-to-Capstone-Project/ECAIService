using ECAIService.Data;
using ECAIService.PipelineDto;
using System.ComponentModel.DataAnnotations;
using ECAIService.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ML.Data;
using Microsoft.ML;

using OneOf;
using Npgsql;
using ECAIService.Models;
using ECAIService.MLModelTables;
using Microsoft.EntityFrameworkCore;
using Pgvector.EntityFrameworkCore;
using System.Collections.Immutable;
using static System.Net.Mime.MediaTypeNames;
using Pgvector;

namespace ECAIService.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TransformerController(
    ExternalTransformer transformer,
    CVOSContext cVOSContext,
    VariantFeaturesSelector variantTextSelector
    ) : ControllerBase
{
    [HttpGet("[action]")]
    public IEnumerable<float[]> Transform(string text)
    {
        return transformer.Transform(text).Select(i => i.SentenceEmbedding!);
    }

    [HttpDelete("[action]")]
    public async Task DeleteAsync(string variantId)
    {
        cVOSContext.VariantTextEmbeddings.Remove((await cVOSContext.VariantTextEmbeddings.FindAsync(variantId))!);

        await cVOSContext.SaveChangesAsync();
    }

    [HttpPut("[action]")]
    public async Task CalculateVectors(bool truncateTable = false)
    {
        if (truncateTable)
        cVOSContext.VariantTextEmbeddings.RemoveRange(cVOSContext.VariantTextEmbeddings
            );

        var variants = cVOSContext.ProductVariants
            .Include(i => i.Product)
            .ToArray();

        foreach (var i in variants)
        {
            if (truncateTable.Not() && cVOSContext.VariantTextEmbeddings.Find(i.Id) is not null)
                continue;

            var text = variantTextSelector.Select(i);
            var embeddings = transformer.Transform(text).Select(i => i.SentenceEmbedding!).First()
            .Let(ProcessModelOutput)            
            ;

            await cVOSContext.VariantTextEmbeddings.AddAsync(new VariantTextEmbedding
            {
                VariantId = i.Id,
                Embeddings = new(embeddings)
            });
            await cVOSContext.SaveChangesAsync();
        }
    }

    private float[] ProcessModelOutput(float[] output)
    {
        int sequenceLength = 128;
        int hiddenSize = 768;

        var unflattened = output
        .Select((i, index) => (value: i, index))
        .GroupBy(i => i.index / 768)
        .Select(i =>
            i.Select(i =>
                i.value
            ).ToArray()
        ).ToArray();

        float[] pooledEmbedding = new float[hiddenSize];
        for (int j = 0; j < hiddenSize; j++)
        {
            float sum = 0f;
            for (int i = 0; i < sequenceLength; i++)
            {
                sum += unflattened[i][j];
            }
            pooledEmbedding[j] = sum / sequenceLength;
        }

        return pooledEmbedding;
    }

    [HttpPut("[action]")]
    public async Task CalculateVector(string variantId)
    {
        var variant = await cVOSContext.ProductVariants
            .Include(i => i.Product)
            .Where(i => i.Id == variantId)
            .FirstOrDefaultAsync() ?? throw new KeyNotFoundException(variantId);

        var text = variantTextSelector.Select(variant);
        var flattenedEmbeddings = transformer.Transform(text).Select(i => i.SentenceEmbedding!).Single();

        int sequenceLength = 128;
        int hiddenSize = 768;

        var embeddings = flattenedEmbeddings.Let(ProcessModelOutput);


        await cVOSContext.VariantTextEmbeddings.AddAsync(new VariantTextEmbedding
        {
            VariantId = variantId,
            Embeddings = new(embeddings)
        });

        await cVOSContext.SaveChangesAsync();
    }

    [HttpGet("[action]")]
    public async Task<IEnumerable<OneOf<string, DistanceResult<string>>>> Neighbors(
        [Required] string variantId,
        int page = 1,
        int size = 20,
        bool distance = false)
    {

        var vector = (await cVOSContext.VariantTextEmbeddings
            .Include(i => i.Variant)
            .Where(i => i.VariantId == variantId)
            .FirstOrDefaultAsync()
            )
            ?? throw new KeyNotFoundException(variantId);

        var result = await cVOSContext.VariantTextEmbeddings
            .Include(i => i.Variant)
            .Where(i => i.Variant.ProductId != vector.Variant.ProductId)
            .Select(i => new
            {
                i.VariantId,
                Distance = vector.Embeddings.L2Distance(i.Embeddings)
            })
            .OrderBy(i => i.Distance)
            .Skip((page - 1) * size)
            .Take(size)
            .ToListAsync();

        return result
            .Select(i => (OneOf<string, DistanceResult<string>>)(distance.Not() ? i.VariantId : new DistanceResult<string>(i.VariantId, i.Distance)));
    }

    [HttpGet("[action]")]
    public async Task<IEnumerable<OneOf<string, DistanceResult<string>>>> Query(
        [Required] string query,
        int page = 1,
        int size = 20,
        bool distance = false)
    {
        var vector = transformer.Transform(query).Select(i => i.SentenceEmbedding!).First()
            .Let(ProcessModelOutput)
            .Let(it => new Vector(it));

        var result = await cVOSContext.VariantTextEmbeddings
            .Select(i => new
            {
                i.VariantId,
                Distance = vector.L2Distance(i.Embeddings)
            })
            .OrderBy(i => i.Distance)
            .Skip((page - 1) * size)
            .Take(size)
            .ToListAsync();

        return result
            .Select(i => (OneOf<string, DistanceResult<string>>)(distance.Not() ? i.VariantId : new DistanceResult<string>(i.VariantId, i.Distance)));
    }
}

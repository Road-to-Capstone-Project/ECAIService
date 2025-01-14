using Dapper;

using ECAIService.Data;

using Microsoft.AspNetCore.Mvc;
using static ECAIService.Consts;
using Npgsql;
using ECAIService.PipelineDto;
using Microsoft.ML;
using ECAIService.Services.Abstractions;
using Microsoft.ML.Data;
using Pgvector;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECAIService.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ContentBasedVectorController(
        CVOSContext cVOSContext,
        NpgsqlDataSourceBuilder dataSourceBuilder,
        MLContext mLContext,
        IEncodingService encodingService
    ) : ControllerBase
{
    private IEstimator<ITransformer> _transformerChain
        = GenericExtensions.Run(() =>
        {
            var categories = cVOSContext.ProductCategories.Select(it => it.Name)
            .Let(it => encodingService.GetCategories(it));

            var result = mLContext.Transforms.CustomMapping<ContentBasedVectorInput, ContentBasedVectorEncoded>((i, o) =>
            {
                o.VariantId = i.VariantId;
                o.Categories = encodingService.MultiHotEncode<double>(i.Categories, categories);
                o.Weight = i.Weight;
                o.Price = i.Price;
            }, "");

            return result;
        });

    public IEstimator<ITransformer> TransformerChain { 
        get {
            var categories = cVOSContext.ProductCategories.Select(it => it.Name)
            .Let(it => encodingService.GetCategories(it));

            var result = mLContext.Transforms.CustomMapping<ContentBasedVectorInput, ContentBasedVectorEncoded>((i, o) =>
            {
                o.VariantId = i.VariantId;
                o.Categories = encodingService.MultiHotEncode<double>(i.Categories, categories);
                o.Weight = i.Weight;
                o.Price = i.Price;
            }, "");

            return result;
        }
    }

    // DELETE api/<ContentBasedVectorController>/5
    [HttpDelete("[action]")]
    public async Task Delete(string variantId)
    {
        using var dataSource = dataSourceBuilder.Build();
        using var npgsqlConnection = dataSource.CreateConnection();

        await npgsqlConnection.ExecuteAsync($"DELETE FROM {ContentBasedVectorTable} WHERE variant_id = @VariantId",
            new { VariantId = variantId });
    }

    [HttpPost("[action]")]
    public async Task CalculateVectors()
    {
        using var dataSource = dataSourceBuilder.Build();
        using var npgsqlConnection = dataSource.CreateConnection();

        await npgsqlConnection.ExecuteAsync($"TRUNCATE TABLE {ContentBasedVectorTable}");

        var dataView = cVOSContext.ProductVariants
            .Select(i => new
            {
                VariantId = i.Id,
                Categories = i.Product!.ProductCategories.Select(it => it.Name).ToArray(),
                Weight = double.Parse(i.Product!.Weight!),
                Price = (double)cVOSContext.ProductVariantPriceSets.Where(it => it.VariantId == i.Id)
                    .Select(it => 
                        cVOSContext.PriceSets
                        .Where(i => i.Id == it.PriceSetId)
                        .Select(it => 
                            it.Prices
                            .Where(i => i.CurrencyCode == "usd")
                            .Select(i => i.Amount)
                            .First())
                        .First())
                    .First()
            })
            .AsEnumerable()
            .Select(it => new ContentBasedVectorInput()
            {
                VariantId = it.VariantId,
                Categories = it.Categories,
                Weight = it.Weight,
                Price = (double)it.Price
            })
            .Let(it => mLContext.Data.LoadFromEnumerable(it))
            .Let(it => TransformerChain.Fit(it).Transform(it))
            .Let(it => mLContext.Data.CreateEnumerable<ContentBasedVectorEncoded>(it, false))
            .Select(it => new ContentBasedVector()
            {
                VariantId = it.VariantId,
                Embeddings = it.ToVector()
            })
            .ToList();

        var first = dataView.FirstOrDefault();

        if (first is null) return;

        await npgsqlConnection.ExecuteAsync($"ALTER TABLE {ContentBasedVectorTable} ALTER COLUMN " +
            $"{nameof(ContentBasedVector.Embeddings).ToLower()} TYPE vector({first.Embeddings.Memory.Length})");

        foreach(var vector in dataView)
        {
            await npgsqlConnection.ExecuteAsync(
                $"INSERT INTO {ContentBasedVectorTable} (variant_id, " +
                $"{nameof(ContentBasedVector.Embeddings).ToLower()}) VALUES (@VariantId, @Embeddings)",
                new { vector.VariantId, vector.Embeddings }
            );
        }
    }

    [HttpPost("[action]")]
    public async Task CalculateVector(string variantId)
    {
        using var dataSource = dataSourceBuilder.Build();
        using var npgsqlConnection = dataSource.CreateConnection();

        var dataView = cVOSContext.ProductVariants
            .Where(i => i.Id == variantId)
            .Select(it => new
            {
                VariantId = it.Id,
                Categories = it.Product!.ProductCategories.Select(it => it.Name).ToArray(),
                Weight = int.Parse(it.Product!.Weight!),
                Price = cVOSContext.ProductVariantPriceSets.Where(it => it.VariantId == it.Id)
                    .Select(it =>
                        cVOSContext.PriceSets
                        .Where(i => i.Id == it.PriceSetId)
                        .Select(it =>
                            it.Prices
                            .Where(i => i.CurrencyCode == "usd")
                            .Select(i => i.Amount)
                            .FirstOrDefault())
                        .FirstOrDefault())
                    .FirstOrDefault()
            })
            .AsEnumerable()
            .Select(it => new ContentBasedVectorInput()
            {
                VariantId = it.VariantId,
                Categories = it.Categories,
                Weight = it.Weight,
                Price = (double)it.Price
            })
            .Let(it => mLContext.Data.LoadFromEnumerable(it))
            .Let(it => TransformerChain.Fit(it).Transform(it))
            .Let(it => mLContext.Data.CreateEnumerable<ContentBasedVectorEncoded>(it, false))
            .Select(it => new ContentBasedVector()
            {
                VariantId = it.VariantId,
                Embeddings = it.ToVector()
            })
            .ToList();

        var first = dataView.First();

        await npgsqlConnection.ExecuteAsync($"ALTER TABLE {ContentBasedVectorTable} ALTER COLUMN " +
            $"{nameof(ContentBasedVector.Embeddings).ToLower()} TYPE vector({first.Embeddings.Memory.Length})");

        foreach (var vector in dataView)
        {
            var databaseVector = await npgsqlConnection.QueryFirstOrDefaultAsync<Vector>(
                $"SELECT {nameof(ContentBasedVector.Embeddings).ToLower()} FROM {ContentBasedVectorTable} WHERE variant_id = @variantId",
                new { variantId }
);
            if (databaseVector is null)
            {
                await npgsqlConnection.ExecuteAsync(
                    $"INSERT INTO {ContentBasedVectorTable} (variant_id, " +
                    $"{nameof(ContentBasedVector.Embeddings).ToLower()}) VALUES (@VariantId, @Embeddings)",
                    new { vector.VariantId, vector.Embeddings }
                );
            }
            else
            {
                await npgsqlConnection.ExecuteAsync(
                    $"UPDATE {ContentBasedVectorTable} SET " +
                    $"{nameof(ContentBasedVector.Embeddings).ToLower()} = @Embeddings " +
                    $"WHERE variant_id = @VariantId",
                    new { vector.VariantId, vector.Embeddings }
                );
            }
        }
    }

    [HttpGet("[action]")]
    public async Task<IEnumerable<string>> Neighbors([Required] string variantId, [Required] int count, bool distance = false)
    {
        using var dataSource = dataSourceBuilder.Build();
        using var npgsqlConnection = dataSource.CreateConnection();

        var vector = await npgsqlConnection.QueryFirstOrDefaultAsync<Vector>(
            $"SELECT {nameof(ContentBasedVector.Embeddings).ToLower()} FROM {ContentBasedVectorTable} WHERE variant_id = @variantId",
            new { variantId }
        );
        if (vector is null)
        {
            return [];
        }

        var productId = await npgsqlConnection.QueryFirstOrDefaultAsync<string>(
            $"SELECT product_id FROM public.product_variant WHERE id = @variantId",
            new { variantId }
        );

        var result = await npgsqlConnection.QueryAsync<DistanceResult<string>>(
            $"SELECT variant_id AS id, " +
            $"{nameof(ContentBasedVector.Embeddings).ToLower()} <-> @vector AS distance " +
            $"FROM {ContentBasedVectorTable} " +
            $"WHERE variant_id <> @variantId " +
            $"AND product_id <> @productId " +
            $"ORDER BY distance " +  // Added space before "LIMIT"
            $"LIMIT @count",
            new { vector, count, variantId, productId }
        );

        return result.Select(i => distance ? i.ToString() : i.Id);
    }
}

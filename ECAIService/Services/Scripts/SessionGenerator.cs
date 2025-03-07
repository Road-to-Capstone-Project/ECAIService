
using Dapper;

using ECAIService.Data;
using ECAIService.PipelineDto;

using Npgsql;
using Npgsql.Internal;

using Pgvector;

using static ECAIService.Consts;

namespace ECAIService.Services.Scripts;

public class SessionGenerator(Random random,
        CVOSContext cVOSContext,
        NpgsqlConnectionDisposables npgsqlConnectionDisposables)
    : IAsyncScript
{

    public async Task<object?> ExecuteAsync()
    {
        using var u = npgsqlConnectionDisposables;
        var (dataSource, connection) = npgsqlConnectionDisposables;
        var variants = cVOSContext.ProductSalesChannels.Where(i => i.SalesChannelId == "google-play")
            .Select(i => i.ProductId)
            .Select(i => cVOSContext.Products.Where(j => j.Id == i).First()!.ProductVariants.FirstOrDefault())
            .Where(i => i != null)
            .ToArray();

        var path = "Resources/sessions2.txt";

        File.WriteAllText(
            path,
            Enumerable.Range(0, 10000)
            .Select(i =>
                Enumerable.Range(0, random.Next(1, 20))
                .Aggregate(
                    new List<string>(),
                    (acc, i) =>
                    {
                        if (i == 0 || random.Next(0, 1000) == -1)
                        {
                            var variant = variants[random.Next(0, variants.Length)];
                            acc.Add(variant!.Id);
                        }
                        else
                        {
                            var variantId = acc[i - 1];

                            var vector = connection.QueryFirst<Vector>(
                                $"SELECT {nameof(ContentBasedVector.Embeddings).ToLower()} FROM {ContentBasedVectorTable} WHERE variant_id = @variantId",
                                new { variantId }
                            );

                            var count = 40;

                            var result = connection.Query<DistanceResult<string>>(
                                $"SELECT id, distance " +
                                $"FROM (" +
                                $"    SELECT variant_id AS id, " +
                                $"    {nameof(ContentBasedVector.Embeddings).ToLower()} <-> @vector AS distance " +
                                $"    FROM {ContentBasedVectorTable} " +
                                $"    WHERE variant_id <> @variantId " +
                                $") " +
                                $"WHERE distance < 3 " +
                                $"ORDER BY distance " +
                                $"LIMIT @count",
                                new { vector, count, variantId }
                            ).ToArray();

                            if (result.Length < 3)
                            {
                                result = connection.Query<DistanceResult<string>>(
                                $"SELECT id, distance " +
                                $"FROM (" +
                                $"    SELECT variant_id AS id, " +
                                $"    {nameof(ContentBasedVector.Embeddings).ToLower()} <-> @vector AS distance " +
                                $"    FROM {ContentBasedVectorTable} " +
                                $"    WHERE variant_id <> @variantId " +
                                $") " +
                                $"ORDER BY distance " +
                                $"LIMIT @count",
                            
                                new { vector, count, variantId }
                            ).ToArray();
                            }

                            var variant = result[random.Next(0, Math.Min(count, result.Length))].Let(it => cVOSContext.ProductVariants.Find(it.Id));

                            acc.Add(variant!.Id);
                        }
                        return acc;
                    }
                )
                .Let(Enumerable.Reverse)
                .Distinct()
                .Reverse()
                .Let(it => string.Join(";", it))
            )
            .Let(it => string.Join("\n", it))
        );

        return await GenericExtensions.NullTask;
    }
}

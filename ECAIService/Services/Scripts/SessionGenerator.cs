using Dapper;

using ECAIService.Data;
using ECAIService.PipelineDto;

using Npgsql;
using Npgsql.Internal;

using Pgvector;

using static ECAIService.Consts;

namespace ECAIService.Services.Scripts;

public class SessionGenerator
{
    public SessionGenerator(
        Random random,
        CVOSContext cVOSContext,
        NpgsqlConnectionDisposables npgsqlConnectionDisposables)
    {
        using var u = npgsqlConnectionDisposables;
        var (dataSource, connection) = npgsqlConnectionDisposables;
        var variants = cVOSContext.ProductVariants.ToArray();

        var path = "Resources/sessions.txt";

        File.WriteAllText(
            path,
            Enumerable.Range(0, 10000)
            .Select(i =>
                Enumerable.Range(0, random.Next(1, 20))
                .Aggregate(
                    new List<string>(),
                    (acc, i) =>
                    {
                        if (i == 0 || random.Next(0, 1000) == 0)
                        {
                            var variant = variants[random.Next(0, variants.Length)];
                            acc.Add(variant.Id);
                        }
                        else
                        {
                            var variantId = acc[i - 1];

                            var vector = connection.QueryFirst<Vector>(
                                $"SELECT {nameof(ContentBasedVector.Embeddings).ToLower()} FROM {ContentBasedVectorTable} WHERE variant_id = @variantId",
                                new { variantId }
                            );

                            var count = 40;

                            var result = connection.Query<string>(
                                $"SELECT variant_id FROM {ContentBasedVectorTable} " +
                                $"WHERE variant_id <> @variantId " +
                                $"ORDER BY {nameof(ContentBasedVector.Embeddings).ToLower()} <-> @vector " +
                                $"LIMIT @count",
                                new { vector, count, variantId }
                            ).ToArray();

                            var variant = result[random.Next(0, count)].Let(it => cVOSContext.ProductVariants.Find(it));

                            acc.Add(variant!.Id);
                        }
                        return acc;
                    }
                )
                .Let(it => string.Join(";", it))
            )
            .Let(it => string.Join("\n", it))
        );
    }
}

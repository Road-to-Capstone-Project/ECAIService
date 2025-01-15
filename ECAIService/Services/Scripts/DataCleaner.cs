
using ECAIService.PipelineDto;

using Microsoft.ML;

namespace ECAIService.Services.Scripts;

public class DataCleaner(
        MLContext mLContext
    ) : IAsyncScript
{

    public async Task<object?> ExecuteAsync()
    {
        using var fileStream = new FileStream("Resources/googleplaystoreCleaned.csv", FileMode.Create);

        mLContext.Data.LoadFromTextFile<GooglePlayAppUnparsed>(
            "Resources/googleplaystore.csv",
            ',',
            true,
            true,
            true,
            true
        )
        .Let(it => mLContext.Data.CreateEnumerable<GooglePlayAppUnparsed>(it, false))
        .Where(i =>
            i.AppName.Let(string.IsNullOrEmpty).Not() &&
            i.Rating.Let(it => double.TryParse(it, out _)) &&
            i.Rating.Let(double.Parse).Let(double.IsNaN).Not() &&
            i.Size.Let(it => it.AsSpan(0, it.Length - 1)
                .Let(it => double.TryParse(it, out _))
            ) &&
            i.Price.Let(it => it == "0" ||
                it[0] == '$' && double.TryParse(it.AsSpan(1), out _)
            )
        )
        .DistinctBy(i => i.AppName.Let(ImportGooglePlayApps.ToHandle))
        .Let(it => mLContext.Data.LoadFromEnumerable(it))
        .Apply(it => mLContext.Data.SaveAsText(it, fileStream,
'\t',
true,
true
        ));

        return await GenericExtensions.NullTask;
    }
}

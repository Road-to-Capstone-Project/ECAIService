using ECAIService.Services.Abstractions;

using Microsoft.ML.Data;

using System.Collections.Frozen;
using System.Numerics;

namespace ECAIService.Services;

public class EncodingService : IEncodingService
{
    public IReadOnlyDictionary<string, int> GetCategories(IEnumerable<string> data, string seperator = ";")
    {
        return data.SelectMany(i => i.Split(seperator)).Distinct()
            .Zip((0..int.MaxValue).GetEnumerable()).ToFrozenDictionary(i => i.First, i => i.Second);
    }

    public VBuffer<T> MultiHotEncode<T>(IEnumerable<string> currentCategories, IReadOnlyDictionary<string, int> categoryMap, T positiveValue, T negativeValue)
    {
        var array = Enumerable.Repeat(negativeValue, categoryMap.Count).ToArray();

        foreach (var j in currentCategories)
        {
            var index = categoryMap[j];
            array[index] = positiveValue;
        };

        return new VBuffer<T>(categoryMap.Count, array);
    }
}

using System.Numerics;

using Microsoft.ML.Data;

namespace ECAIService.Services.Abstractions;
public interface IEncodingService
{
    IReadOnlyDictionary<string, int> GetCategories(IEnumerable<string> data, string seperator = ";");
    VBuffer<T> MultiHotEncode<T>(IEnumerable<string> currentCategories, IReadOnlyDictionary<string, int> categoryMap)
        where T : INumber<T> => MultiHotEncode(currentCategories, categoryMap, T.One, T.Zero);

    VBuffer<T> MultiHotEncode<T>(IEnumerable<string> currentCategories, IReadOnlyDictionary<string, int> categoryMap, T positiveValue, T negativeValue);
}
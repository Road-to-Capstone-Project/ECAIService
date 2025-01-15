
using ECAIService.Data;

namespace ECAIService.Services.Scripts;

public class TokenDictionaryService(CVOSContext cVOSContext) : IAsyncScript
{
    public async Task<object?> ExecuteAsync()
    {
        var tokens = await File.ReadAllLinesAsync("Resources/sessions.txt")
            .LetAsync(i => i
                .Select(i => i.Split(';'))
                .SelectMany(i => i)
            );

        var tokenDictionary = cVOSContext.ProductVariants.Select(i => i.Id)
            .ToDictionary(i => i, i => 0);

        var counter = 0;

        foreach (var token in tokens)
        {
            counter++;
            tokenDictionary[token]++;
        }

        await File.WriteAllTextAsync("Resources/tokenDictionary.csv", counter + "\n" + string.Join("\n", tokenDictionary.OrderByDescending(i => i.Value).Select(it => $"{it.Key}\t{it.Value}")));

        return null;
    }
}

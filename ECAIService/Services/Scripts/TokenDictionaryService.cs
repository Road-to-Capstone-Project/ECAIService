using ECAIService.Data;

namespace ECAIService.Services.Scripts;

public class TokenDictionaryService
{
    public TokenDictionaryService(CVOSContext cVOSContext)
    {
        var tokens = File.ReadAllLines("Resources/sessions.txt").Select(i => i.Split(';'))
            .SelectMany(i => i);

        var tokenDictionary = cVOSContext.ProductVariants.Select(i => i.Id)
            .ToDictionary(i => i, i => 0);

        var counter = 0;

        foreach (var token in tokens)
        {
            counter++;
            tokenDictionary[token]++;
        }

        File.WriteAllText("Resources/tokenDictionary.csv", counter + "\n" + string.Join("\n", tokenDictionary.OrderByDescending(i => i.Value).Select(it => $"{it.Key}\t{it.Value}")));
    }
}

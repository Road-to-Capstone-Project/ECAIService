
using Microsoft.ML;

namespace ECAIService.Services.Scripts;

public class SessionToCSV(
    ILogger<SessionToCSV> logger
) : IAsyncScript
{
    public async Task<object?> ExecuteAsync()
    {
        using var read = File.OpenRead("Resources/sessions.txt");

        await File.WriteAllTextAsync("Resources/sessions.csv", "");

        using var write = File.AppendText("Resources/sessions.csv");

        var sessions =
            (await File.ReadAllLinesAsync("Resources/sessions.txt"))
            .Select(i => i.Split(';'))
            .Take(10000)
            .ToArray()
            ;

        await write.WriteLineAsync("Previous,Current");

        foreach (var session in sessions)
        {
            if (session.Length < 2) continue;

            await write.WriteAsync($"{session.Take(session.Length - 1).Let(string.Join, " ")}");
            await write.WriteLineAsync($",{session.Last()}");
        }

        Console.WriteLine("SessionToCSV done.");

        return null;
    }
}

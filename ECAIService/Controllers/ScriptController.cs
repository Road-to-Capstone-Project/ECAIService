using ECAIService.Services.Scripts;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace ECAIService.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ScriptController(
        IServiceProvider serviceProvider,
        GNNService gNNService
    )
{
    [HttpGet]
    public IEnumerable<string> GetAvailableScripts()
    {
        return serviceProvider.GetServices<IAsyncScript>().Select(i => i.GetType().Name);
    }

    public record RunScriptsResponse(IEnumerable<string> ScriptsRan);

    [HttpPost]
    public async Task<RunScriptsResponse> RunScripts([FromQuery(Name = "s")] ICollection<string> scripts)
    {
        var result = await scripts
            .Select(i => serviceProvider.GetKeyedService<IAsyncScript>(i))
            .Where(i => i is not null) 
            .Select(async i =>
            {
                await i!.ExecuteAsync();
                return i.GetType().Name;
            }).Let(Task.WhenAll);

        return new(result);
    }

    [HttpPost("[action]")]
    public async Task GNN([FromQuery(Name = "i")] ICollection<string> sequence)
    {
        gNNService.Sequence = sequence;
        await gNNService.ExecuteAsync();
    }
}

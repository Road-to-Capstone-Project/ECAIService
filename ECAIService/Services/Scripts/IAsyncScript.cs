namespace ECAIService.Services.Scripts;

public interface IAsyncScript
{
    public Task<object?> ExecuteAsync();
}

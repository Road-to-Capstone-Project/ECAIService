using Npgsql;

namespace ECAIService.Data;

public sealed record NpgsqlConnectionDisposables(NpgsqlDataSource DataSource, NpgsqlConnection Connection) : IDisposable
{
    public void Dispose()
    {
        DataSource.Dispose();
        Connection.Dispose();
    }
}

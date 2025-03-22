using System.Data;
using Npgsql;

namespace Infrastructure.Data;

public class DataContext
{
    private const string ConnectionString = "Host=localhost;Username=postgres;Database=WebApiPractice_db;Password=ipo90";

    public IDbConnection GetConnection()
    {
        return new NpgsqlConnection(ConnectionString);
    }
}

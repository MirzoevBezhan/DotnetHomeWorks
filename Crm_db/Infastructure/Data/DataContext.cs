using System.Data;
using Npgsql;

namespace  Infastructure;
public class DataContext
{
    private string ConnectionString = "Host=localhost;Username=postgres;Password=ipo90;Database=Crm_db";
    
    public IDbConnection GetConnection()
    {
        return new NpgsqlConnection(ConnectionString);
    }
}

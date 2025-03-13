using System.Data;
using Domain;
using Npgsql;

namespace Infastructure;

public class ScreeningServce 
{
    string connectionString = "Host=localhost;Database=task3_db;Username=postgres;Password=ipo90";
    public void Task15()
    {
        var cmd = $"SELECT * FROM screenings WHERE ticket_price > (SELECT AVG(ticket_price) FROM screenings);";
        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd, connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            foreach (DataTable dt in ds.Tables)
            {
                foreach (DataColumn column in dt.Columns)
                    Console.Write($"{column.ColumnName}\t");
                Console.WriteLine();
                foreach (DataRow row in dt.Rows)
                {
                    var cells = row.ItemArray;
                    foreach (object cell in cells)
                        Console.Write($"{cell}\t");
                    Console.WriteLine();
                }
            }
        }

    }
    public void Task16(){
        var cmd = $"select s.screen_id,count(t.screening_id) as total_tickets from  screenings as s left join  tickets AS t ON s.screen_id = t.screening_id gorup by s.screen_id order by  s.screen_id";
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var adapter = new NpgsqlDataAdapter(cmd, connectionString);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            foreach (DataTable dt in ds.Tables)
            {
                foreach (DataColumn column in dt.Columns)
                {
                    System.Console.WriteLine($"{column.ColumnName}\t");
                }
                System.Console.WriteLine();

                foreach (DataRow row in dt.Rows)
                {
                    var cells = row.ItemArray;
                    foreach (var cell in cells)
                    {
                        System.Console.WriteLine($"{cell}\t");
                    }
                }
            }
        }
    }
    
    public void Task20(){
        var cmd = $"select t.theater_id,t.name,count(s.theater_id) from theaters as t join screenings as s on t.theater_id = s.theater_id group by t.theater_id , t.name ;";
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var adapter = new NpgsqlDataAdapter(cmd, connectionString);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            foreach (DataTable dt in ds.Tables)
            {
                foreach (DataColumn column in dt.Columns)
                {
                    System.Console.WriteLine($"{column.ColumnName}\t");
                }
                System.Console.WriteLine();

                foreach (DataRow row in dt.Rows)
                {
                    var cells = row.ItemArray;
                    foreach (var cell in cells)
                    {
                        System.Console.WriteLine($"{cell}\t");
                    }
                }
            }
        }
    }
    
}




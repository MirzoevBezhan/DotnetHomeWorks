namespace Infastructure;

using System.Data;
using Domain;
using Npgsql;

public class TicketService 
{
    string connectionString = "Host=localhost;Database=task3_db;Username=postgres;Password=ipo90";

    public void Task15()
    {
        var cmd = $"select theaters.name,avg(t.price) as ticket_theater from screenings as s join tickets as t on s.ticket_id = t.screening_id join theaters as th on th.theater_id=s.theater_id group by th.name";
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var adapter = new NpgsqlDataAdapter(cmd, connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            foreach (DataTable dt in ds.Tables)
            {
                foreach (DataColumn column in dt.Columns)
                {
                    System.Console.WriteLine($"{column.ColumnName} \t");
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

    public void Task20()
    {
        var cmd = $"SELECT ti.ticket_id, m.title AS film_name, t.name AS theater_name FROM tickets AS ti JOIN screenings AS s ON ti.screening_id = s.screen_id JOIN movies AS m ON s.movie_id = m.movie_id JOIN theaters AS t ON s.theater_id = t.theater_id;";
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var adapter = new NpgsqlDataAdapter(cmd, connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            foreach (DataTable dt in ds.Tables)
            {
                foreach (DataColumn column in dt.Columns)
                {
                    System.Console.WriteLine($"{column.ColumnName} \t");
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
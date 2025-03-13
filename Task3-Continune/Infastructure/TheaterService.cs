using System.Data;
using Domain;
using Npgsql;

namespace Infastructure;

public class TheaterService
{
        string connectionString = "Host=localhost;Database=task3_db;Username=postgres;Password=ipo90";
        public void Task13(int num)
        {
                var cmd = $"select  t.name from theaters as t join screenings as s on t.id=s.theater_id group by t.name having count(s.id)>{num} ";
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
        public void Task17()
        {
                var cmd = $"select t.name,avg(t.price) from screenings as s join tickets as ti on s.screen_id = ti.screening_id join theaters as t on t.theater_id = s.theater_id group by t.name";
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
        public void Task19(string movie_name)
        {
                var cmd = $"SELECT * FROM theaters WHERE id  IN (SELECT theater_id FROM screenings as s JOIN movies as m ON s.movie_id = m.movie_id WHERE m.title = {movie_name} );";
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

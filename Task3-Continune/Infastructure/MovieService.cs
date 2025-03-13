namespace Infastructure;

using System.Data;
using Domain;
using Npgsql;

public class MovieService 
{
    string connectionString = "Host=localhost;Database=task3_db;Username=postgres;Password=ipo90";

    public void task11()
    {
        string sql = "select title from movies where duration = (select max(duration) from movies))";
        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(sql, connection);
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
    public void task12()
    {
        string sql = "select m.title,t.theater_id from screenings as s join movies as m on m.movie_id = s.movie_id join theaters as t on t.theater_id = s.theater_id group by m.title,t.theater_id having count(t.theater_id)>0";
        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(sql, connection);
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

    public void Task14()
    {

        var cmd = $"select m.title,sum(s.ticket_price) as viruchka from movies as m join screenings as s on m.movie_id = s.movie_id group by m.movie_id";
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
    public void Task18(){
     var cmd = $"SELECT * FROM movies WHERE duration > (SELECT AVG(duration) FROM movies );";
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

}




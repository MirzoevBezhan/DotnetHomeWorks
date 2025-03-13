using Domain;
using Npgsql;

namespace Infastructure;

public class MovieService
{
    private const string connectionString = "Host=localhost;Username=postgres;Password=Shahmlbb7;Database=movie_db";

    public int CreateMovie(Movie movie)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            var cmd = $"insert into movies (title, director, year)" + 
                      $"values ('{movie.Title}',  '{movie.Director}',  {movie.Year})";
            var command = new NpgsqlCommand(cmd, connection);
            var result = command.ExecuteNonQuery();
            return result;
        }
    }
    public List<Movie> GetMovies()
    {
        var Movies = new List<Movie>();

        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            var cmd = "select * from movies ";
            var command = new NpgsqlCommand(cmd, connection);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var movie = new Movie()
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Director = reader.GetString(2),
                        Year = reader.GetInt32(3)
                    };
                    Movies.Add(movie);
                }
            }
        }
        return Movies;
    }

    public int UpdateMovie(Movie movie)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            var cmd = $"update movies set title='{movie.Title}', director = '{movie.Director}',  year = {movie.Year} where id={movie.Id}";
            var command = new NpgsqlCommand(cmd, connection);
            var result = command.ExecuteNonQuery();
            return result;
        }
    }

    public int DeleteMovie(int id)
    {
        using (var  connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            var cmd = $"delete from movies where id={id}";
            var command = new NpgsqlCommand(cmd, connection);
            var result = command.ExecuteNonQuery();
            return result;
            
            
        }
    }

    public void some()
    {
        string sql = "SELECT * FROM Users";
        using (NpgSqlConnection  connection = new NpgSqlConnection(connectionString))
        {
            // Создаем объект DataAdapter
            NpgSqlDataAdapter adapter = new NpgSqlDataAdapter(sql, connection);
            // Создаем объект DataSet
            DataSet ds = new DataSet();
            // Заполняем Dataset
            adapter.Fill(ds);
        }
        Console.Read();
    }
}
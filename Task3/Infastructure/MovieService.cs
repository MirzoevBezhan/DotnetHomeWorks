namespace Infastructure;
using Domain;
using Npgsql;

public class MovieService : IMovieService
{
  string connectionString = "Host=localhost;Database=task3_db;Username=postgres;Password=ipo90";

    public List<Movie> Task1(string genre)
    {
          var movies = new List<Movie>();
       using (var con = new NpgsqlConnection(connectionString))
       {
            con.Open();
            var cmd = $"select * from movies where genre = {genre} ";
            var command = new NpgsqlCommand(cmd,con);   
          using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var movie = new Movie()
                    {
                        movie_id = reader.GetInt32(0),
                        title = reader.GetString(1),
                        director = reader.GetString(2),
                        year = reader.GetInt32(3),
                        duration = reader.GetInt32(4),
                        genre = reader.GetString(5),
                        description = reader.GetString(6)
                    };
                    movies.Add(movie);
                }
            }
        }
return movies;
    }
    public List<string> Task2()
    {
               var movies = new List<string>();
       using (var con = new NpgsqlConnection(connectionString))
       {
            con.Open();
            var cmd = $"select DISTINCT (director) from movies ";
            var command = new NpgsqlCommand(cmd,con);   
          using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string director; 
                    {
                        director=reader.GetString(0);
                    };
                movies.Add(director);
                }
            }
        }
        return movies;
    }


    public List<Movie> Task4()
    {
         var movies = new List<Movie>();
       using (var con = new NpgsqlConnection(connectionString))
       {
            con.Open();
            var cmd = $"select * from movies  as d order by year desc";
            var command = new NpgsqlCommand(cmd,con);   
          using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var movie = new Movie()
                    {
                        movie_id = reader.GetInt32(0),
                        title = reader.GetString(1),
                        director = reader.GetString(2),
                        year = reader.GetInt32(3),
                        duration = reader.GetInt32(4),
                        genre = reader.GetString(5),
                        description = reader.GetString(6)
                    };
                    movies.Add(movie);
                }
            }
        }
return movies;
    }
}
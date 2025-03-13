using System.Data;
using Domain;
using Npgsql;

namespace Infastructure;

public class ScreeningServce : IScreeningServce
{
    string connectionString = "Host=localhost;Database=task3_db;Username=postgres;Password=ipo90";
    public List<screenings> Task3()
    {
        var screenings = new List<screenings>();
        using (var con = new NpgsqlConnection(connectionString))
        {
            con.Open();
            var cmd = $"select * from screenings order by screening_time";
            var command = new NpgsqlCommand(cmd, con);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var screen = new screenings()
                    {
                        screen_id = reader.GetInt32(0),
                        movie_id = reader.GetInt32(1),
                        theater_id = reader.GetInt32(2),
                        screening_time = reader.GetDateTime(3),
                        ticket_price = reader.GetDecimal(4),
                        available_seats = reader.GetInt32(5)
                    };
                    screenings.Add(screen);
                }
            }
            return screenings;
        }
    }

    public List<screenings> Task5()
    {
        var screenings = new List<screenings>();
        using (var con = new NpgsqlConnection(connectionString))
        {
            con.Open();
            var cmd = $"select * from screenings limmit 5 ";
            var command = new NpgsqlCommand(cmd, con);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var screen = new screenings()
                    {
                        screen_id = reader.GetInt32(0),
                        movie_id = reader.GetInt32(1),
                        theater_id = reader.GetInt32(2),
                        screening_time = reader.GetDateTime(3),
                        ticket_price = reader.GetDecimal(4),
                        available_seats = reader.GetInt32(5)
                    };
                    screenings.Add(screen);
                }
            }
            return screenings;
        }
    }

    public void Task6()
    {
        using (var con = new NpgsqlConnection(connectionString))
        {
               int count;
               string title;
            con.Open();
            var cmd = $"select count(s.screen_id),m.title from screenings as s join movies as m on m.movie_id = s.movie_id group by movie_id";
            var command = new NpgsqlCommand(cmd, con);
             using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                  count=reader.GetInt32(0);
                  title=reader.GetString(1);
            System.Console.WriteLine(count);
            System.Console.WriteLine(title);
                }
            }
        }
        }
    }

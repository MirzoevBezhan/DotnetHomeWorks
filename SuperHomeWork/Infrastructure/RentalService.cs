using Dapper;
using Domain;
using Npgsql;

namespace Infrastructure;

public class RentalService
{
    string connectionString = "Host=localhost;Database=Rentcar_db;Password=ipo90;Username=postgres";
    public List<Rentals> GetAllRentals()
    {
        using (var con = new NpgsqlConnection(connectionString))
        {
            con.Open();
            var cmd = $"select * from rentals";
            var rentals = con.Query<Rentals>(cmd, con).ToList();
            return rentals;
        }
    }
    public void AddRent(int customer, int car, DateTime sarshavi, DateTime budshidan)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            var carprice = "select price_per_day from cars where id = @carsid";
            var totalsum = connection.QuerySingle<decimal>(carprice, new { carsid = car });
            int days = (budshidan - sarshavi).Days;
            var vsego = days * totalsum;
            var AddingRent = "insert into rentals (customer_id, car_id, start_date, end_date, total_cost) values (@ClientId, @CarId, @StartDate, @EndDate, @TotalCost)";

            int countOfAddedRents = connection.Execute(AddingRent, new
            {
                customer_id = customer,
                car_Id = car,
                start_date = sarshavi,
                end_date = budshidan,
                totalcost = vsego
            });
            System.Console.WriteLine(countOfAddedRents);
        }
    }
    public Rentals GetRentalById(int id)
    {
        using (var con = new NpgsqlConnection(connectionString))
        {
            con.Open();
            var cmd = $"select * from rentals where rental_id = @id";
            var rentals = con.Query<Rentals>(cmd, new { Id = id }).FirstOrDefault();
            return (Rentals)rentals;
        }
    }
}


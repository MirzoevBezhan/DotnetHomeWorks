namespace Infrastructure;

using Dapper;
using Domain;
using Npgsql;

public class CarService
{
    string connectionString = "Host=localhost;Database=Rentcar_db;Password=ipo90;Username=postgres";
    public void AddCar(Car car)
    {
        using (var con = new NpgsqlConnection(connectionString))
        {
            con.Open();
            string cmd = "insert into cars (model, manufacter, year, price_per_day) values (@model, @manufacter, @year, @price_per_day)";
                var result = con.Execute(cmd, new {  model = car.model, manufacter = car.manufacter, year = car.year, price_per_day = car.price_per_day });
            System.Console.WriteLine(result);
        }
    }
    public List<Car> GetAllCars()
    {
        using (var con = new NpgsqlConnection(connectionString))
        {
            con.Open();
            var cmd = $"select * from cars";
            var cars = con.Query<Car>(cmd, con).ToList();
            return cars;
        }
    }
    public Car GetCarById(int id)
    {
        using (var con = new NpgsqlConnection(connectionString))
        {
            con.Open();
            var cmd = $"select * from cars where car_id = @id";
            var car = con.Query<Car>(cmd, new { Id = id }).FirstOrDefault();
            return (Car)car;
        }
    }
    public int UpdateCar(Car car)
    {
        using (var con = new NpgsqlConnection(connectionString))
        {
            con.Open();
            var cmd = "update cars set model = @Model, manufacter = @Manufacter, year = @Year, price_per_day = @PricePerDay where car_id = @Id";
            var result = con.Execute(cmd, new { Model = car.model, Manufacter = car.manufacter, Year = car.year, PricePerDay = car.price_per_day, Id = car.car_id });
            return result;
        }
    }
    public int DeleteCarById(int id)
    {
        using (var con = new NpgsqlConnection(connectionString))
        {
            con.Open();
            var cmd = "delete from cars where car_id = @Id";
            var result = con.Execute(cmd, new { Id = id });
            return result;
        }
    }
}
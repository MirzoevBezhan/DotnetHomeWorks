using Dapper;
using Domain;
using Npgsql;

namespace Infrastructure;

public class CustomerService
{
     string connectionString = "Host=localhost;Database=Rentcar_db;Password=ipo90;Username=postgres";
 public void AddCustomer(Customers customers)
    {
        using (var con = new NpgsqlConnection(connectionString))
        {
            con.Open();
            var cmd = $"insert into customers (full_name,phone,email) values(@full_name , @phone , @email)";
            var result = con.Execute(cmd, new { full_name = customers.full_name, phone = customers.phone, email = customers.email });
            System.Console.WriteLine(result);
        }
    }
    public List<Car> GetAllCustomers()
    {
        using (var con = new NpgsqlConnection(connectionString))
        {
            con.Open();
            var cmd = $"select * from customers";
            var customers = con.Query<Car>(cmd, con).ToList();
            return customers;
        }
    }
    public Customers GetCustomerById(int id)
    {
        using (var con = new NpgsqlConnection(connectionString))
        {
            con.Open();
            var cmd = $"select * from customers where customer_id = @id";
            var customer = con.Query<Customers>(cmd, new { Id = id }).FirstOrDefault();
            return (Customers)customer;
        }
    }
    public int UpdateCustomer(Customers customers)
    {
        using (var con = new NpgsqlConnection(connectionString))
        {
            con.Open();
            var cmd = "update customers set full_name = @full_name, phone = @phone, email = @email where customer_id = @Id";
            var result = con.Execute(cmd, new { full_name = customers.full_name, phone = customers.phone, email = customers.email,  Id = customers.customer_id });
            return result;
        }
    }
    public int DeleteCustomerById(int id)
    {
        using (var con = new NpgsqlConnection(connectionString))
        {
            con.Open();
            var cmd = "delete from customers where customer_id = @Id";
            var result = con.Execute(cmd, new { Id = id });
            return result;
        }
    }
}
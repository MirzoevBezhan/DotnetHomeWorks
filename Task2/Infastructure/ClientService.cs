using System.Data;
using Npgsql;

namespace Infastructure;

using Domain;

public class ClientService : IClientService
{
    const string connectionString = "Host=localhost;Database=task_2db;Username=postgres;Password=ipo90";

    public void get()
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            var cmd = "select * from movies ";
            var adapter = new NpgsqlDataAdapter(cmd, connection);

            var dataset = new DataSet();
            adapter.Fill(dataset);
            
            var table = dataset.Tables[0];

            foreach (var column in table.Columns)
            {
                Console.WriteLine(column + "\t");
            }

            foreach (DataRow row in table.Rows)
            {
                Console.WriteLine($"{row[0]}\t{row[1]}\t{row[2]}{row[3]}");
            }
        }

    } 

    public int addclient(Client client)
    {
        using (var con = new NpgsqlConnection(connectionString))
        {
            con.Open();
            var cmd =
                "insert into clients values (client.full_name, client.birthdate,client.email,client.phone,client.adress,client.account_num,client.account_type,client.balance,client.branch,client.created_at,client.updated_at)";
            var command = new NpgsqlCommand(cmd, con);
            var res = command.ExecuteNonQuery();
            return res;
        }
    }


    public List<Client> GetAllclients()
    {
        var departments = new List<Client>();

        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();

            var cmd = "select * from departments";
            var command = new NpgsqlCommand(cmd, connection);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var client = new Client()
                    {
                        client_id = reader.GetInt32(0),
                        full_name = reader.GetString(1),
                        birthdate = reader.GetDateTime(2),
                        email = reader.GetString(3),
                        phone = reader.GetString(4),
                        address = reader.GetString(5),
                        account_num = reader.GetString(6),
                        account_type = reader.GetString(7),
                        balance = reader.GetDecimal(8),
                        branch = reader.GetString(9),
                        created_at = reader.GetDateTime(10),
                        updated_at = reader.GetDateTime(11)
                    };
                    departments.Add(client);
                }
            }
        }

        return departments;
    }

    public Client getclientbyid(int client_idd)
    {
        using (var com = new NpgsqlConnection(connectionString))
        {
            var client3 = new Client();
            com.Open();
            var cmd = $"select * from clients where client_id={client_idd}";
            var command = new NpgsqlCommand(cmd, com);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var client2 = new Client()
                    {
                        client_id = reader.GetInt32(0),
                        full_name = reader.GetString(1),
                        birthdate = reader.GetDateTime(2),
                        email = reader.GetString(3),
                        phone = reader.GetString(4),
                        address = reader.GetString(5),
                        account_num = reader.GetString(6),
                        account_type = reader.GetString(7),
                        balance = reader.GetDecimal(8),
                        branch = reader.GetString(9),
                        created_at = reader.GetDateTime(10),
                        updated_at = reader.GetDateTime(11)
                    };
                    client3 = client2;
                }

                return client3;
            }
        }
    }

    public void updateclient(Client client)
    {
        using (var con = new NpgsqlConnection(connectionString))
        {
            con.Open();
            var cmd =
                $"update clients where client_id={client.client_id} set {client.full_name},{client.birthdate},{client.email},{client.phone},{client.address},{client.account_num},{client.account_type},{client.balance},{client.branch},{client.created_at},{client.updated_at}";
            var command = new NpgsqlCommand(cmd, con);
            Console.WriteLine("Client updated");
        }
    }

    public void deleteclient(int client_id)
    {
        using (var con = new NpgsqlConnection(connectionString))
        {
            con.Open();
            var cmd = $"delete from clients where client_id={client_id}";
            Console.WriteLine("Client deleted");
        }
    }

    public Client getrichesclient()
    {
        var client = new Client();
        using (var con = new NpgsqlConnection(connectionString))
        {
            con.Open();
            var cmd = "select * from clients group by full_name balance desc limit 1";
            var command = new NpgsqlCommand(cmd, con);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var client2 = new Client()
                    {
                        client_id = reader.GetInt32(0),
                        full_name = reader.GetString(1),
                        birthdate = reader.GetDateTime(2),
                        email = reader.GetString(3),
                        phone = reader.GetString(4),
                        address = reader.GetString(5),
                        account_num = reader.GetString(6),
                        account_type = reader.GetString(7),
                        balance = reader.GetDecimal(8),
                        branch = reader.GetString(9),
                        created_at = reader.GetDateTime(10),
                        updated_at = reader.GetDateTime(11)
                    };
                    client = client2;
                }
                    return client;
            }
        }
    }

    public int getclientcount()
    {
        using (var con = new NpgsqlConnection(connectionString))
        {
            con.Open();
            var cmd = "select count(*) from clients";
            var command = new NpgsqlCommand(cmd, con);
            var res = command.ExecuteScalar();
            return Convert.ToInt32(res);
        }
    }

    public decimal getaveragebalance()
    {
        using (var con = new NpgsqlConnection(connectionString))
        {
            con.Open();
            var cmd = "select avg(balance) from clients";
            var command = new NpgsqlCommand(cmd, con);
            var res = command.ExecuteScalar();
            return Convert.ToInt32(res);
        }
    }
}
    

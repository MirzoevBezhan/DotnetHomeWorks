using System.Threading.Channels;
using Domain;
using Infastructure;

ClientService clientService = new ClientService();
foreach (var item in clientService.GetAllClients())
{
    System.Console.WriteLine();
    System.Console.WriteLine($"Account Num : {item.account_num}");
    System.Console.WriteLine($"Account Type : {item.account_type}");
    System.Console.WriteLine($"Address  : {item.address}");
    System.Console.WriteLine($"Balance : {item.balance}");
    System.Console.WriteLine($"Date : {item.birthdate}");
    System.Console.WriteLine($"Branch : {item.branch}");
    System.Console.WriteLine($"Client ID : {item.client_id}");
    System.Console.WriteLine($"Created_at : {item.created_at}");
    System.Console.WriteLine($"Email : {item.email}");
    System.Console.WriteLine($"FullName : {item.full_name}");
    System.Console.WriteLine();
}

 
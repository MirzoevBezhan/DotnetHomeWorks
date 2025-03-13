using System.Threading.Channels;
using Domain;
using Infastructure;

ClientService clientService = new ClientService();
//
// Console.WriteLine("1. Добавить пользователя");
// Console.WriteLine("2. Вывести всех пользователей");
// Console.WriteLine("3. Найти клиента по ID");
// Console.WriteLine("4. Обновить данные о клиенте");
// Console.WriteLine("5. Удалить клиента");
// Console.WriteLine("6. Найти клиента с наибольшим балансом я");
// Console.WriteLine("7. Количество всех клиентов");
// Console.WriteLine("8. Средний баланс клиентов");
// Console.WriteLine("9. Остановить Программу ");
// Console.WriteLine();
// Console.WriteLine("Выбери команду : ");
// int funk = Convert.ToInt32(Console.ReadLine());
// switch (funk)
// {
//     case 1:
//         Client client = new Client();
//         Console.Write("Имя :");
//         string name = Console.ReadLine();
//         Console.Write("Фамилия :");
//         string lastname = Console.ReadLine();
//         client.full_name = name + lastname;
//         Console.WriteLine("День рождения :");
//         DateTime birthday = DateTime.Parse(Console.ReadLine());
//         client.birthdate= birthday;
//         Console.WriteLine("Введите почту :");
//         string email = Console.ReadLine();
//         client.email = email;
//         Console.WriteLine("Введите номер телефона :");
//         string phone = Console.ReadLine();
//         client.phone = phone;
//         Console.WriteLine("Ваш адресс :");
//         string address = Console.ReadLine();
//         client.address = address;
//         Console.WriteLine("Номера аккаунта :");
//         string accountnum = Console.ReadLine();
//         client.account_num = accountnum;
//         break;
// }
clientService.get();
int a = 10;
int v = 1;
Console.WriteLine("Hello World!");

Console.WriteLine();
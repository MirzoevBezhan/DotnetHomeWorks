using System.Collections.Concurrent;
using Domain;
using Infrastructure;


CarService carService = new CarService();
// foreach (var item in carService.GetAllCars())
// {

//     System.Console.Write("Car ID : " + item.car_id + " ");
//     System.Console.WriteLine(item.model);
//     System.Console.WriteLine(item.manufacter);
// }


// System.Console.Write("Which car do you search : ");
// int id = int.Parse(Console.ReadLine());
//  Car car = carService.GetCarById(id);
//  System.Console.WriteLine(car.car_id);
//  System.Console.WriteLine(car.model);

// Car myCar = new Car
// {
//     car_id = 12,
//     model = "Toyota Corolla",
//     manufacter = "Toyota",
//     year = 2020,
//     price_per_day = 50
// };

// carService.AddCar(myCar);


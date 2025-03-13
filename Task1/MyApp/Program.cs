using Domain;
using Infastructure;

var MovieService = new MovieService();

while (true)
{
    Console.WriteLine();
    Console.WriteLine("1. Просмотреть все фильмы.");
    Console.WriteLine("2. Найти фильм по ID.");
    Console.WriteLine("3. Добавить новый фильм.");
    Console.WriteLine("4. Обновить информацию о фильме.");
    Console.WriteLine("5. Удалить фильм.");
    Console.WriteLine("6. Остановить программу.");
    Console.WriteLine();
    var input = Console.ReadLine();
    if (input == "1")
    {
        var list = MovieService.GetMovies();
        foreach (var movie in list)
        {
            Console.WriteLine($"{movie.Id}\t{movie.Title}\t{movie.Director}\t{movie.Year}");
        }
    }

    if (input == "2")
    {
        Console.Write("Which ID ?: ");
        var id = int.Parse(Console.ReadLine());
        var list = MovieService.GetMovies();
        foreach (var movie in list)
        {
            if (id == movie.Id)
            {
                Console.WriteLine($"{movie.Id}\t{movie.Title}\t{movie.Director}\t{movie.Year}");
            }
        }
    }

    if (input == "3")
    {
        var Movies = new Movie();
        Console.Write("Title: ");
        Movies.Title  = Console.ReadLine();
        
        Console.Write("Director: ");
        Movies.Director = Console.ReadLine();
        
        Console.Write("Year: ");
        Movies.Year = int.Parse(Console.ReadLine());

        var result = MovieService.CreateMovie(Movies);
        Console.WriteLine($"{result} row added.");
    }

    if (input == "4")
    {
        Console.Write("Id for update movie: ");
        var id = int.Parse(Console.ReadLine());
        Console.Write("Title for update: ");
        var title = Console.ReadLine();
        var list = MovieService.GetMovies();
        foreach (var movie in list)
        {
            if (id == movie.Id)
            {
                movie.Title = title;
                Console.WriteLine("Title updated.");
            }
        }
    }

    if (input == "5")
    {
        Console.WriteLine("Id for deleted movie ?: ");
        var id = int.Parse(Console.ReadLine());
        MovieService.DeleteMovie(id);
        Console.WriteLine($"That's {id} movie deleted.");
    }

    if (input == "6")
    {
        Console.WriteLine("You arledy logged out.");
        break;
    }
}


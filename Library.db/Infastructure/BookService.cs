using Dapper;
using Domain;
using Npgsql;

namespace Infastructure;

public class BookService : IBookService
{
    private string connectionString = "Host=localhost;Username=postgres;Password=ipo90;DataBase=library_db";
    public int AddBook(Book book)
    {
        using (var com = new NpgsqlConnection(connectionString))
        {
            com.Open();
            var cmd = "insert into Books (Title,Genre,PublicationYear,TotalCopies,availableCopies) values(@Title , @Genre, @PublicationYear , @TotalCopies , @availableCopies)";
            var res = com.Execute(cmd, new { Title = book.Title, Genre = book.Genre, PublicationYear = book.PublicationYear, TotalCopies = book.TotalCopies, availableCopies = book.availableCopies });
            return res;
        }
    }
    public List<Book> GetAllBooks()
    {
        using (var com = new NpgsqlConnection(connectionString))
        {
            com.Open();
            var cmd = "select * from books";
            var res = com.Query<Book>(cmd).ToList();
            return res;
        }
    }
    public Book GetBookById(int bookId)
    {
        using (var com = new NpgsqlConnection(connectionString))
        {
            com.Open();
            var cmd = "select * from books where BookId = @bookId";
            var res = com.QuerySingle<Book>(cmd, new {bookId = bookId});
            return res;
        }
    }
    public int UpdateBook(Book book)
    {
        using (var con = new NpgsqlConnection(connectionString))
        {
            con.Open();
            var cmd = "update books set title = @title, genre = @genre, publicationyear = @publicationyear where bookId = @BookId";
            var result = con.Execute(cmd, book);
            return result;
        }
    }
    public int DeleteBook(int num)
    {
        using (var con = new NpgsqlConnection(connectionString))
        {
            con.Open();
            var cmd = "delete from books where bookid = @bookId";
            var result = con.Execute(cmd, num);
            return result;
        }
    }
}

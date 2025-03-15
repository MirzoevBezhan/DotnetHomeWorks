using Dapper;
using Domain;
using Infastructure;
using Npgsql;

public class BoorrowingService : IBorrowingsService
{
    private string connectionString = "Host=localhost;Username=postgres;Password=ipo90;DataBase=library_db";

    public void CheckAvailableCopies(int bookId, int member, DateTime borrowDate, DateTime DueDate)
    {
        using (var com = new NpgsqlConnection(connectionString))
        {
            com.Open();
            var cmd = "select availableCopies from books where BookId = @BookId";
            int copi = com.QuerySingle<int>(cmd, new { BookId = bookId });
            if (copi < 0)
            {
                System.Console.WriteLine("Don't have borrowing");
            }

            string cmd2 = "insert into borrowings (bookId, memberId, borrowDate, dueDate) values (@BookId ,@MemberId, @BorrowDate, @DueDate)";
            var res = com.Execute(cmd2, new { BookId = bookId, MemberId = member, BorrowDate = borrowDate, DueDate = DueDate });
            string cmd3 = "update books set availableCopies = availableCopies - 1 where bookId = @bookId";
            var res2 = com.Execute(cmd3, new { bookId = bookId });
            System.Console.WriteLine($"Added {res2} rows ");
        }
    }
    public List<Borrowing> GetAllBorrowings()
    {
        using (var com = new NpgsqlConnection(connectionString))
        {
            com.Open();
            var cmd = "select * from borrowings";
            var res = com.Query<Borrowing>(cmd).ToList();
            return res;
        }
    }
    public Borrowing GetBorrowById(int borrowId)
    {
        using (var com = new NpgsqlConnection(connectionString))
        {
            com.Open();
            var cmd = "select * from borrowings where borrowingId = @borrowId";
            var res = com.QuerySingle<Borrowing>(cmd, new { borrowingId = borrowId });
            return res;
        }
    }


}

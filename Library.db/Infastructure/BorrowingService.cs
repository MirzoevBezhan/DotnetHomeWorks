using Dapper;
using Domain;
using Infastructure;
using Microsoft.VisualBasic;
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
    public int GetFine(int bookId, int borrowId, DateTime returnDate)
    {

        using (var com = new NpgsqlConnection(connectionString))
        {
            com.Open();
            var cmd = "select duedate from borrowings where borrowingId = @borrowingId";
            var res = com.Execute(cmd, new { borrowId = borrowId });
            if (returnDate.Day > res)
            {
                var cmd2 = "update borrowings set fine = 0+5 where borrowingId = @borrowingId";
                var res2 = com.Execute(cmd, new { borrowId = borrowId });
                var cmd3 = "update books set AvailableCopies + 1 where bookId = @bookId";
                var res3 = com.Execute(cmd, new { bookId = bookId });
                return res2;
            }
            else
            {
                return 0;
            }
        }
    }
    public Book Task1()
    {
        using (var com = new NpgsqlConnection(connectionString))
        {
            com.Open();
            var cmd = "select * ,count(bo.bookId) from books as bo join borrowings as b on b.bookId = bo.bookId group by bo.bookId,b.borrowingId order by bo.bookId desc";
            var res = com.QuerySingleOrDefault<Book>(cmd);
            return res;
        }
    }
    public Members Task2()
    {
        using (var com = new NpgsqlConnection(connectionString))
        {
            com.Open();
            var cmd = "select m.fullname,count(b.memberId) from members as m join borrowings as b on b.memberId = m.memberId group by m.Fullname order by count(b.memberId) desc";
            var res = com.QuerySingleOrDefault<Members>(cmd);
            return res;
        }
    }
    public int Task3()
    {
        using (var com = new NpgsqlConnection(connectionString))
        {
            com.Open();
            var cmd = "select count(*) from borrowings";
            ///// ай ма 0 меброра барои ки да pgAdmin инсертш чизера хато мега ма намедонм чияй у
            var res = com.Execute(cmd);
            return res;
        }
    }

    public decimal Task4()
    {
        using (var com = new NpgsqlConnection(connectionString))
        {
            com.Open();
            var cmd = "select avg(fine) from borrowings";
            var res = com.Execute(cmd);
            return res;
        }
    }

    public List<Book> Task5()
    {
        using (var com = new NpgsqlConnection(connectionString))
        {
            com.Open();
            var cmd = "select * from books as bo join borrowings as b on b.bookId = bo.bookId group by bo.bookId,b.borrowingId having b.returnDate>CURRENT_DATE";
            var res = com.Query<Book>(cmd).ToList();
            return res;
        }
    }
    public List<Book> Task6()
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = $"select * FROM Books  as b join borrowings as bo on b.bookId = bo.bookId";
            var res = connection.Query<Book>(sql).ToList();
            return res;
        }
    }
    public List<Book> Task7()
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = $" select * from books  where AvailableCopies = 0";
            var res = connection.Query<Book>(sql).ToList();
            return res;
        }
    }
    public int Task8()
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = $"select count(*) from books where bookId not in (select bookId from borrowings)";
            var res = connection.ExecuteScalar<int>(sql);
            return res;
        }
    }
    public decimal Task13()
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            string sql = "select sum(fine) from borrowings";
            var res = connection.QuerySingleOrDefault<decimal>(sql);
            return res;
        }
    }
    public int Task14()
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            string sql = "select count(*) from borrowings where returnDate > dueDate";
            var res = connection.ExecuteScalar<int>(sql);
            return res;
        }
    }
}

namespace Infastructure;
using Domain;
public interface IBookService
{
  public int AddBook(Book book);
    public List<Book> GetAllBooks();
    public Book GetBookById(int bookId);
    public int UpdateBook(Book book);
    public int DeleteBook(int num);
}

namespace Infastructure;
using Domain;
public interface IBorrowingsService
{
     public void CheckAvailableCopies(int bookId, int member, DateTime borrowDate, DateTime DueDate);
    public List<Borrowing> GetAllBorrowings();
    public Borrowing GetBorrowById(int borrowId);
}

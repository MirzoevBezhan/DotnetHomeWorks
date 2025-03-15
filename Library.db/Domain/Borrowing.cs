using Microsoft.VisualBasic;

namespace Domain;

public class Borrowing
{
    public int BorrowingId;
    public int BookId;
    public int MemberId;
    public DateTime BorrowDate;
    public DateTime DueDate;
    public DateTime? ReturnDate;
    public decimal Fine;
}

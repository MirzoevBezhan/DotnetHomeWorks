using Domain;
using Infastructure;

BookService bookService = new BookService();

// Book book = new Book();
// book.Title = "Something";
// book.Genre = "Man";
// book.PublicationYear = 2020;
// book.TotalCopies = 10;
// book.availableCopies=4;

// System.Console.WriteLine(bookService.AddBook(book));
// System.Console.WriteLine(bookService.DeleteBook(1));
// foreach (var item in bookService.GetAllBooks())
// {
//     System.Console.WriteLine($"Name:  {item.Title}");
//     System.Console.WriteLine();
// }

// System.Console.WriteLine(bookService.DeleteBook(2));

var memberService = new MemberService();

// System.Console.WriteLine(memberService.DeleteMember(1));

// foreach (var item in memberService.GetAllMember())
// {
//     System.Console.WriteLine();
//     System.Console.WriteLine(item.Email);
//     System.Console.WriteLine(item.FullName);
//     System.Console.WriteLine(item.Phone);
//     System.Console.WriteLine();
// }

var borrowservice = new BoorrowingService();
// DateTime dateTime =  DateTime.Now;
// borrowservice.CheckAvailableCopies(1,2,dateTime,dateTime);

// foreach (var item in borrowservice.GetAllBorrowings())
// {
//     System.Console.WriteLine();
//     System.Console.WriteLine(item.BookId);
//     System.Console.WriteLine(item.MemberId);
//     System.Console.WriteLine(item.BorrowingId);
//     System.Console.WriteLine(item.DueDate);
//     System.Console.WriteLine();
// }

// var example = borrowservice.GetBorrowById(2);

// System.Console.WriteLine(example.ReturnDate);
// System.Console.WriteLine(example.DueDate);
// System.Console.WriteLine(example.BookId);
// System.Console.WriteLine(example.BorrowingId);
// borrowservice.GetFine(1,2,DateTime.Now);

// Book book = borrowservice.Task1();
// System.Console.WriteLine(book.BookId);
// System.Console.WriteLine(book.availableCopies);
// System.Console.WriteLine(book.Genre);
// foreach (var item in borrowservice.Task5())
// {
//     System.Console.WriteLine();
//     System.Console.WriteLine(item.BookId);
//     System.Console.WriteLine();
// }

// foreach (var item in borrowservice.Task6())
// {
//     System.Console.WriteLine();
//     System.Console.WriteLine(item.BookId);
//     System.Console.WriteLine();
// } 
// System.Console.WriteLine(borrowservice.Task14());


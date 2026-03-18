//active loans should show which member borrowed which book

//future perspective: add borrowDate and ReturnDate
namespace LibraryApp.Models;

public class Loan
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public int MemberId { get; set; }  
    public bool IsActive { get; set; } = true; //active or returned
}
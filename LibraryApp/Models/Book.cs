//i did not know but ISBN is international standard book number
//10 digit number
namespace LibraryApp.Models;
public class Book
{
    public int Id { get; set;}
    public string Title {get; set; }= "";
    public string Author {get;set;} = "";
    public string Isbn {get; set;} = "";
    public string Description {get; set;}= "";
    public bool IsAvailable {get; set;} = true; //useful for borrow/return or if member sees the book at all

    public string AvailabilityText => IsAvailable ? "Available" : "Not available";

    public string LoanedBy { get; set; } = "";
}
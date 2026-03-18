/*
View available books in the catalog.
• View currently borrowed books.
• View book details (Title, Author, ISBN, Description, etc.).
• Borrow available books.
• Return borrowed books.
*/

namespace LibraryApp.Models;
public class Member
{
    public int Id { get; set;}
    public string Name { get; set;} = "";
    public string UserName { get; set;} = "";
    public string Password { get; set;} = "";
}
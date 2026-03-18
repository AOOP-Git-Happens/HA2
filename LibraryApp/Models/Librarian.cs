/*
• View the full catalog they manage.
• Add new books to the catalog.
• Edit book details.
• Delete books from the catalog.
• View a list of all active loans in the system (tracking which member has borrowed which
book)
*/

namespace LibraryApp.Models;

public class Librarian
{
    public int Id { get; set; }
    public string Name {get; set; }= "";
    public string UserName {get; set;} = "";
    public string Password {get; set;} = "";
}
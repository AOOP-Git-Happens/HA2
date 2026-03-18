//works with BOOK DATA, load/save them, help with borrow/return?

using System.Collections.Generic;
using LibraryApp.Models;
namespace LibraryApp.Repository;

public class BookStore
{
    public List<Book> Books { get; set; } = new List<Book>();
    public List<Loan> Loans {get; set;} = [];

    public void LoadBooks()
    {
        
    }

    public void LoadLoans()
    {
        
    }
}
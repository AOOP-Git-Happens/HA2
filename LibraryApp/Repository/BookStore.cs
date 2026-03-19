//works with BOOK DATA, load/save them, help with borrow/return?
//maybe later helper methods like add/remove and update? :)

using System.Collections.Generic;
using LibraryApp.Models;
namespace LibraryApp.Repository;

using System.IO;
using System.Text.Json;

public class BookStore
{
    public List<Book> Books { get; set; } = new List<Book>();
    public List<Loan> Loans { get; set; } = [];

    public BookStore()
    {
        LoadBooks();
    }
    public void LoadBooks()
    {
        if (!File.Exists("Assets/books.json"))
        {
            Books = new List<Book>();
            return;
        }

        var json = File.ReadAllText("Assets/books.json");
        Books = JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>();
    }

    public void LoadLoans()
    {

    }
}
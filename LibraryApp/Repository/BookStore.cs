using System.Collections.Generic;
using LibraryApp.Models;
using System.IO;
using System.Text.Json;

namespace LibraryApp.Repository;

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

    public void SaveBooks()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonSerializer.Serialize(Books, options);
        File.WriteAllText("Assets/books.json", json);
    }

    public void LoadLoans()
    {

    }
}
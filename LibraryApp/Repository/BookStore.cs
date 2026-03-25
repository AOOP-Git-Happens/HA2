using System.Collections.Generic;
using LibraryApp.Models;
using System.IO;
using System.Text.Json;

//book data lives here and saved to json

namespace LibraryApp.Repository;

public class BookStore
{
    private readonly string _booksFilePath; //better for testing, to avoid main file manipulation
    public List<Book> Books { get; set; } = new List<Book>();
    public List<Loan> Loans { get; set; } = [];

    // Constructor now accepts file path (used by tests to avoid modifying main file)
    public BookStore(string booksFilePath = "Assets/books.json")
    {
        _booksFilePath = booksFilePath;
        LoadBooks();
    }

    public void LoadBooks()
    {
        if (!File.Exists(_booksFilePath))
        {
            Books = new List<Book>();
            return;
        }

        var json = File.ReadAllText(_booksFilePath);
        Books = JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>();
    }

    public void SaveBooks()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonSerializer.Serialize(Books, options);
        File.WriteAllText(_booksFilePath, json);
    }

    public void LoadLoans()
    {

    }
}
using System;
using CommunityToolkit.Mvvm.ComponentModel;
using LibraryApp.Models;
using LibraryApp.Repository;
using CommunityToolkit.Mvvm.Input;

//title, author, isbn, description; save and cancel
namespace LibraryApp.ViewModels;

public partial class BookEditorViewModel : ViewModelBase
{
    private readonly BookStore _bookStore;
    private readonly Book? _editingBook;
    private readonly Action _goBackToCatalog;

    public BookEditorViewModel(BookStore bookStore, Book? editingBook, Action goBackToCatalog)
    {
        _bookStore = bookStore;
        _editingBook = editingBook;
        _goBackToCatalog = goBackToCatalog;

        if (_editingBook != null) //== means add book; != means edit book
        {
            Title = _editingBook.Title;
            Author = _editingBook.Author;
            Isbn = _editingBook.Isbn;
            Description = _editingBook.Description;
        }
    }

    [ObservableProperty]
    private string title = "";
    [ObservableProperty]
    private string author = "";
    [ObservableProperty]
    private string isbn = "";
    [ObservableProperty]
    private string description = "";

    [CommunityToolkit.Mvvm.Input.RelayCommand]
    private void Save()
    {
        if (_editingBook == null)
        {
            var newBook = new Book
            {
                Title = Title,
                Author = Author,
                Isbn = Isbn,
                Description = Description,
                IsAvailable = true,
                LoanedBy = ""
            };

            _bookStore.Books.Add(newBook);
        }
        else
        {
            _editingBook.Title = Title;
            _editingBook.Author = Author;
            _editingBook.Isbn = Isbn;
            _editingBook.Description = Description;
        }

        _bookStore.SaveBooks();
        _goBackToCatalog();
    }
    [RelayCommand]
    private void Cancel()
    {
        _goBackToCatalog();
    }
}
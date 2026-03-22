using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LibraryApp.Models;
using LibraryApp.Repository;

namespace LibraryApp.ViewModels;

public partial class LibraryCatalogViewModel : ViewModelBase
{
    private readonly BookStore _bookStore;
    private readonly CatalogMode _catalogMode;

    public ObservableCollection<Book> Books { get; } = new();

    [ObservableProperty]
    private Book? selectedBook;

    [ObservableProperty]
    private string searchText = "";

    public LibraryCatalogViewModel(BookStore bookStore, CatalogMode catalogMode)
    {
        _bookStore = bookStore;
        _catalogMode = catalogMode;
        LoadBooks();
    }

    [RelayCommand]
    private void Borrow(Book bookToBorrow)
    {
        if (bookToBorrow != null)
        {
            bookToBorrow.IsAvailable = false;
            bookToBorrow.LoanedBy = UserStore.LoggedInUsername;

            if (_catalogMode == CatalogMode.Member)
            {
                Books.Remove(bookToBorrow);
            }
            
            // Save the changes to the JSON file
            _bookStore.SaveBooks();
        }
    }

    private void LoadBooks()
    {
        Books.Clear();

        foreach (var book in _bookStore.Books)
        {
            if (_catalogMode == CatalogMode.Member)
            {
                if (book.LoanedBy == "")
                {
                    Books.Add(book);
                }
            }
            else
            {
                Books.Add(book);
            }
        }
    }
}
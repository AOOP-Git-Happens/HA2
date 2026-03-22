/*
1. list of books shown in catalog
2. selected book
3. search/filter text
4. borrow command for members
5. maybe edit/delete commands for librarians if you reuse same page???
*/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using LibraryApp.Models;
using LibraryApp.Repository;

namespace LibraryApp.ViewModels;

public partial class LibraryCatalogViewModel : ViewModelBase
{
    //receives data from 
    private readonly BookStore _bookStore;
    private readonly CatalogMode _catalogMode;

    //1. list of MANY books
    public ObservableCollection<Book> Books { get; } = new();

    //selected books
    [ObservableProperty]
    private Book? selectedBook;

    //3. search text, user input
    [ObservableProperty]
    private string searchText = "";

    public LibraryCatalogViewModel(BookStore bookStore, CatalogMode catalogMode)
    {
        _bookStore = bookStore;

        _catalogMode = catalogMode;

        LoadBooks();
    }

    private void LoadBooks()
    {
        Books.Clear();

        foreach (var book in _bookStore.Books)
        {
            if (_catalogMode == CatalogMode.Member)
            {
                // member is able to see all the boks that arent rented by a member
                if (book.LoanedBy == "")
                {
                    Books.Add(book);
                }
            }
            else
            {
                // Librarian sees all books
                Books.Add(book);
            }
        }
    }
}
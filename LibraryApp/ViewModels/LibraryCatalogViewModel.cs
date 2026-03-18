/*
1. list of books shown in catalog
2. selected book
3. search/filter text
4. borrow command for members
5. maybe edit/delete commands for librarians if you reuse same page???
*/

using System;
using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using LibraryApp.Models;
using LibraryApp.Repository;

namespace LibraryApp.ViewModels;

public partial class LibraryCatalogViewModel : ViewModelBase
{
    //receives data from 
    private readonly BookStore _bookStore;

    //1. list of MANY books
    public List<Book> Books { get; set; } = new();

    //selected books
    [ObservableProperty]
    private Book? selectedBook;

    //3. search text, user input
    [ObservableProperty]
    private string searchText = "";

    public LibraryCatalogViewModel(BookStore bookStore)
    {
        _bookStore = bookStore;

        Books = _bookStore.Books;
    }
}
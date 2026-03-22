/*
responsible for 1. current (member's) borrowed books
return command
*/

using System;
using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using LibraryApp.Models;
using LibraryApp.Repository;

namespace LibraryApp.ViewModels;

public partial class MyLoansViewModel : ViewModelBase
{
    private readonly BookStore _bookStore;

    public List<Book> MyBorrowedBooks { get; set; } = new();

    public MyLoansViewModel(BookStore bookStore) 
    {
        _bookStore = bookStore;
        
        MyBorrowedBooks = _bookStore.Books
            .Where(book => book.LoanedBy == UserStore.LoggedInUsername)
            .ToList();
    }
}
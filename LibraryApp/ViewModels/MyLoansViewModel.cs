using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using LibraryApp.Models;
using LibraryApp.Repository;
using System.Linq;
using CommunityToolkit.Mvvm.Input;

namespace LibraryApp.ViewModels;

public partial class MyLoansViewModel : ViewModelBase
{
    private readonly BookStore _bookStore;

    public ObservableCollection<Book> MyBorrowedBooks { get; set; }

    public MyLoansViewModel(BookStore bookStore) 
    {
        _bookStore = bookStore;
        
        var borrowedBooks = _bookStore.Books
            .Where(book => book.LoanedBy == UserStore.LoggedInUsername);
            
        MyBorrowedBooks = new ObservableCollection<Book>(borrowedBooks);
    }

    [RelayCommand]
    private void Return(Book bookToReturn)
    {
        if (bookToReturn != null)
        {
            bookToReturn.IsAvailable = true;
            bookToReturn.LoanedBy = ""; 
            MyBorrowedBooks.Remove(bookToReturn);
            
            _bookStore.SaveBooks();
        }
    }
}
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

    //current borrowed books members aka LOAN
    public List <Loan> Loans{ get; set; } = new();

    [ObservableProperty]
    private Loan? selectedLoan;

    public MyLoansViewModel(BookStore bookStore)
    {
        _bookStore = bookStore;
        Loans = _bookStore.Loans;
    }
}
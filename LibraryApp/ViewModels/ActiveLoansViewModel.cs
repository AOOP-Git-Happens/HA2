/* responsible for
currently borrowed books
WHO borrowed each?
total active loan amount/count
*/

using CommunityToolkit.Mvvm.ComponentModel;
using LibraryApp.Models;
using LibraryApp.Repository;
using System.Collections.Generic;

namespace LibraryApp.ViewModels;

public partial class ActiveLoansViewModel : ViewModelBase

{
    private readonly BookStore _bookStore;
    public List<Loan> Loans { get; set; } = new();

    [ObservableProperty]
    private Loan? selectedLoan;

    public ActiveLoansViewModel(BookStore bookStore)
    {
        _bookStore = bookStore;
        Loans = _bookStore.Loans;
    }
}
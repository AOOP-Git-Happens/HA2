/* responsible for
currently borrowed books
WHO borrowed each?
total active loan amount/count
*/

using CommunityToolkit.Mvvm.ComponentModel;
using LibraryApp.Models;
using LibraryApp.Repository;
using System.Collections.Generic;
using System.Linq;

namespace LibraryApp.ViewModels;

public partial class ActiveLoansViewModel : ViewModelBase
{
    private readonly BookStore _bookStore;
    
    public List<Book> ActiveBorrowedBooks { get; set; } = new();

    public ActiveLoansViewModel(BookStore bookStore)
    {
        _bookStore = bookStore;
        
        ActiveBorrowedBooks = _bookStore.Books
            .Where(book => !string.IsNullOrEmpty(book.LoanedBy))
            .ToList();
    }
}
using Avalonia;
using Avalonia.Headless;
using Avalonia.Headless.XUnit;
using Xunit;
using LibraryApp.Models;
using LibraryApp.ViewModels;
using LibraryApp.Repository;
using LibraryApp.Views;
using System.Linq; 

namespace LibraryApp.Tests;

public class UseCaseUITests
{
    // USE CASE I: Member Borrowing a Book
    [AvaloniaFact]
    public void UITest_Member_CanBorrowBook()
    {
        // Arrange
        UserStore.LoggedInUsername = "Bob";
        var store = new BookStore(); // Fixed CS1729
        store.Books.Clear();

        var book = new Book { Title = "1984", IsAvailable = true, LoanedBy = "" }; 
        store.Books.Add(book);

        // Fixed CS7036 by adding CatalogMode and dummy Action parameters
        var viewModel = new LibraryCatalogViewModel(store, CatalogMode.Member, () => {}, (b) => {}); 
        var view = new LibraryCatalogView { DataContext = viewModel };

        // Act - execute borrow action
        viewModel.BorrowCommand.Execute(book); 

        // Assert - verify book is now borrowed by Bob
        Assert.False(book.IsAvailable); 
        Assert.Equal("Bob", book.LoanedBy); 
    }

    // USE CASE II: Member Returning a Book 
    [AvaloniaFact]
    public void UITest_Member_CanReturnBook()
    {
        // Arrange
        UserStore.LoggedInUsername = "Bob";
        var store = new BookStore(); // Fixed CS1729
        store.Books.Clear();

        var book = new Book { Title = "The Hobbit", IsAvailable = false, LoanedBy = "Bob" }; 
        store.Books.Add(book);

        var viewModel = new MyLoansViewModel(store); 
        var view = new MyLoansView { DataContext = viewModel };

        // Act - execute return action
        viewModel.ReturnCommand.Execute(book); 

        // Assert - verify book is available again
        Assert.True(book.IsAvailable); 
        Assert.Equal("", book.LoanedBy); 
        Assert.Empty(viewModel.MyBorrowedBooks); 
    }

    // USE CASE III: Librarian Tracking Active Loans
    [AvaloniaFact]
    public void UITest_Librarian_TracksActiveLoans()
    {
        // Arrange
        UserStore.LoggedInUsername = "AdminLibrarian"; 
        var store = new BookStore(); // Fixed CS1729
        store.Books.Clear();

        // Add one available book and one borrowed book
        store.Books.Add(new Book { Title = "Available Book", IsAvailable = true, LoanedBy = "" });
        store.Books.Add(new Book { Title = "Borrowed Book", IsAvailable = false, LoanedBy = "Alice" });

        var viewModel = new ActiveLoansViewModel(store); 
        var view = new ActiveLoansView { DataContext = viewModel };

        // Act & Assert - Fixed CS1061 by checking the exact property name ActiveBorrowedBooks
        Assert.Single(viewModel.ActiveBorrowedBooks); 
        Assert.Equal("Borrowed Book", viewModel.ActiveBorrowedBooks.First().Title);
        Assert.Equal("Alice", viewModel.ActiveBorrowedBooks.First().LoanedBy);
    }
}
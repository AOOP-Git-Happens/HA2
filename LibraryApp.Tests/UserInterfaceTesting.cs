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
    [AvaloniaFact]
    public void UITest_Member_CanReturnBook()
    {
        var testFile = "test_books_ui.json"; // Use separate file → avoids conflicts with other tests
        // Arrange
        UserStore.LoggedInUsername = "Bob";
        var store = new BookStore(testFile);
        store.Books.Clear();

        //book is borrowed by bob
        var book = new Book { Title = "The Hobbit", IsAvailable = false, LoanedBy = "Bob" }; //not available, loaned by Bob

        store.Books.Add(book);

        //create view model (simulates ui screen)
        var viewModel = new MyLoansViewModel(store); //opens
        var view = new MyLoansView { DataContext = viewModel };

        // Act - execute return action
        viewModel.ReturnCommand.Execute(book); //execute return command

        // Assert - verify correct behaviour 
        Assert.True(book.IsAvailable); //book is available 
        Assert.Equal("", book.LoanedBy); //no one loaned it
        Assert.Empty(viewModel.MyBorrowedBooks); //disappears from bob'ss list
    }

    [AvaloniaFact]
    public void UITest_Librarian_TracksActiveLoans()
    {
        // Arrange
        UserStore.LoggedInUsername = "gru"; 
        var store = new BookStore(); 
        store.Books.Clear();

        // adds one available book and one borrowed book
        store.Books.Add(new Book { Title = "Available Book", IsAvailable = true, LoanedBy = "" });
        store.Books.Add(new Book { Title = "Borrowed Book", IsAvailable = false, LoanedBy = "bob" });

        var viewModel = new ActiveLoansViewModel(store); 
        var view = new ActiveLoansView { DataContext = viewModel };

        // Act & Assert 
        Assert.Single(viewModel.ActiveBorrowedBooks); 
        Assert.Equal("Borrowed Book", viewModel.ActiveBorrowedBooks.First().Title);
        Assert.Equal("bob", viewModel.ActiveBorrowedBooks.First().LoanedBy);
    }
}
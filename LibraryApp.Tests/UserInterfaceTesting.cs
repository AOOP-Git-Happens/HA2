using Avalonia;
using Avalonia.Headless;
using Avalonia.Headless.XUnit;  // Add this line
using Xunit;
using LibraryApp.Models;
using LibraryApp.ViewModels;
using LibraryApp.Repository;
using LibraryApp.Views;
using System.Linq; 
//'using' statements is unnecessary, as we added 'using' for 
//everything inside ...Tests.csproj

namespace LibraryApp.Tests;

public class UseCaseUITests
{
    [AvaloniaFact]
    public void UITest_Member_CanReturnBook()
    {
        // Arrange
        UserStore.LoggedInUsername = "Bob";
        var store = new BookStore();
        store.Books.Clear();
        var book = new Book { Title = "The Hobbit", IsAvailable = false, LoanedBy = "Bob" }; //not available, loaned by Bob
        store.Books.Add(book);

        var viewModel = new MyLoansViewModel(store); //opens
        var view = new MyLoansView { DataContext = viewModel };

        // Act
        viewModel.ReturnCommand.Execute(book); //execute return command

        // Assert
        Assert.True(book.IsAvailable); //book is available 
        Assert.Equal("", book.LoanedBy); //no one loaned it
        Assert.Empty(viewModel.MyBorrowedBooks); //disappears from bob'ss list
    }

}
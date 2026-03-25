using Avalonia;
using Avalonia.Headless;
using Avalonia.Headless.XUnit;  // Add this line
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
        // Arrange
        UserStore.LoggedInUsername = "Bob";
        var store = new BookStore();
        store.Books.Clear();
        var book = new Book { Title = "The Hobbit", IsAvailable = false, LoanedBy = "Bob" };
        store.Books.Add(book);

        var viewModel = new MyLoansViewModel(store);
        var view = new MyLoansView { DataContext = viewModel };

        // Act
        viewModel.ReturnCommand.Execute(book);

        // Assert
        Assert.True(book.IsAvailable);
        Assert.Equal("", book.LoanedBy);
        Assert.Empty(viewModel.MyBorrowedBooks);
    }

}
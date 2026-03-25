using LibraryApp.Repository;
using LibraryApp.Models;
using LibraryApp.ViewModels;

namespace LibraryApp.Tests;

//a member borrows a book

//expected: available becomes false
//loaned by becomes 'bob'
public class BorrowingTests
{
    [Fact]
    public void Borrowing_UpdatesBookStatusCorrectly()
    {
    // Use separate file → prevents interference with other tests
    var testFile = "Assets/test_books_borrowing.json";

    //Arrange - prepare object you need
    UserStore.LoggedInUsername = "Tester Bob"; // username set

    var store = new BookStore(testFile); //create bookstore
    store.Books.Clear(); //clear old data

    //create available book
    var book = new Book //add book
    {
        Title = "The Testing Book",
        IsAvailable = true, //book is initially available
        LoanedBy = ""
    };

    store.Books.Add(book); // add book

    //create viewModel (member mode affects behaviour)
    var viewModel = new LibraryCatalogViewModel(
        store,
        CatalogMode.Member, //valid enum value
        () => {}, //func with no params
        _ => {}   //func with one param
    );

    //Act - do operation you want to test 
    viewModel.BorrowCommand.Execute(book); //borrow book

    //Assert - check if result is correct
    Assert.False(book.IsAvailable);
    Assert.Equal("Tester Bob", book.LoanedBy);
    Assert.DoesNotContain(book, viewModel.Books);
    Assert.Equal("You borrowed \"The Testing Book\" book.", viewModel.StatusMessage);
    
    }
}
using LibraryApp.Repository;
using LibraryApp.Models;
using LibraryApp.ViewModels;

namespace LibraryApp.Tests;

//a user should only see books that THEY borrowed
public class MyLoansFilteringTests
{
    [Fact]
    public void Filtering_ShowsLoansByLoggedUser()
    {
    // Use separate file → prevents interference with other tests
    var testFile = "test_loanedBooks_filtering.json";

    //Arrange - prepare object you need
    UserStore.LoggedInUsername = "Alina"; //logged in user

    var store = new BookStore(testFile); //create bookstore
    store.Books.Clear(); //clear old data

    //create available books
    var book1 = new Book { Title = "Book One", LoanedBy = "Alina" }; 
    var book2 = new Book { Title = "Book Two", LoanedBy = "Alina"};
    var book3 = new Book { Title = "Book Three", LoanedBy = "Jonas"};

    //add books
    store.Books.Add(book1);
    store.Books.Add(book2);
    store.Books.Add(book3);

    //Act - do operation you want to test 
    var viewModel = new MyLoansViewModel(store);

    //Assert - check if result is correct
    Assert.Equal(2, viewModel.MyBorrowedBooks.Count);
    Assert.Contains(viewModel.MyBorrowedBooks, b => b.Title == "Book One");
    Assert.Contains(viewModel.MyBorrowedBooks, b => b.Title == "Book Two");
    Assert.DoesNotContain(viewModel.MyBorrowedBooks, b => b.Title == "Book Three");
    }
}
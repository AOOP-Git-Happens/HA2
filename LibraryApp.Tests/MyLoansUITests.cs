using System.IO; // for file handling (test file creation/cleanup)
using Avalonia.Headless; // enables UI testing without opening real windows
using Avalonia.Headless.XUnit; // integrates Avalonia with xUnit
using Xunit; // testing framework
using LibraryApp.Models; // Book model
using LibraryApp.ViewModels; // ViewModels (MyLoansViewModel)
using LibraryApp.Repository; // BookStore
using LibraryApp.Views; // UI view (MyLoansView)
using System.Linq; // for LINQ operations

namespace LibraryApp.Tests;

// UI test: verify that MyLoans view shows only books borrowed by logged-in user
public class MyLoansUITests
{
    [AvaloniaFact] // special test attribute for Avalonia UI tests
    public void UITest_MyLoans_ShowsOnlyLoggedUserBooks()
    {
        // Use separate test file → avoids interfering with other tests
        var testFile = "test_books_myloans_ui.json";

        // Clean up file before test (ensures fresh start)
        if (File.Exists(testFile))
            File.Delete(testFile);

        // -------------------- ARRANGE --------------------

        // Simulate logged-in user
        UserStore.LoggedInUsername = "Bob";

        // Create BookStore with test file
        var store = new BookStore(testFile);
        store.Books.Clear(); // ensure empty starting state

        // Create test data:
        // Two books borrowed by Bob (should appear)
        var book1 = new Book { Title = "Book One", LoanedBy = "Bob", IsAvailable = false };
        var book2 = new Book { Title = "Book Two", LoanedBy = "Bob", IsAvailable = false };

        // One book borrowed by someone else (should NOT appear)
        var book3 = new Book { Title = "Book Three", LoanedBy = "Alice", IsAvailable = false };

        // Add all books to store
        store.Books.Add(book1);
        store.Books.Add(book2);
        store.Books.Add(book3);

        // Save to file (optional but ensures consistency with UI behavior)
        store.SaveBooks();

        // Create ViewModel (this performs filtering logic)
        var viewModel = new MyLoansViewModel(store);

        // Create View and bind ViewModel (simulates UI)
        var view = new MyLoansView { DataContext = viewModel };

        // -------------------- ACT --------------------

        // No command needed here:
        // filtering already happens inside ViewModel constructor

        // -------------------- ASSERT --------------------

        // Check that only 2 books are visible (Bob’s books)
        Assert.Equal(2, viewModel.MyBorrowedBooks.Count);

        // Check that Bob’s books are present
        Assert.Contains(viewModel.MyBorrowedBooks, b => b.Title == "Book One");
        Assert.Contains(viewModel.MyBorrowedBooks, b => b.Title == "Book Two");

        // Check that Alice’s book is NOT shown
        Assert.DoesNotContain(viewModel.MyBorrowedBooks, b => b.Title == "Book Three");

        // Ensure that the View is properly bound to the ViewModel (UI layer validation)
        Assert.NotNull(view.DataContext);

        // Clean up file after test
        if (File.Exists(testFile))
            File.Delete(testFile);
    }
}
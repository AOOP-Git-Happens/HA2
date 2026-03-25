using Xunit;
using LibraryApp.Models;
using LibraryApp.Repository;

namespace LibraryApp.Tests;

public class DataPersistenceTests
{
    [Fact]
    public void DataPersistence_SavesAndLoads()
    {
        // Arrange
        var store1 = new BookStore();
        store1.Books.Clear();
        store1.Books.Add(new Book { Title = "Test Book" });

        // Act
        store1.SaveBooks();
        var store2 = new BookStore(); 

        // Assert
        Assert.Single(store2.Books); 
        Assert.Equal("Test Book", store2.Books[0].Title); 
    }
}
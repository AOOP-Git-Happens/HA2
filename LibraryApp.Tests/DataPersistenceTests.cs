using Xunit;
using LibraryApp.Models;
using LibraryApp.Repository;

//whatever data is actually saved and loaded correctly
namespace LibraryApp.Tests;

public class DataPersistenceTests
{
    [Fact]
    public void DataPersistence_SavesAndLoads()
    {
        // Arrange
        var store1 = new BookStore(); //creates bookstore
        store1.Books.Clear(); //removes books
        store1.Books.Add(new Book { Title = "Test Book" }); //adds book

        // Act
        store1.SaveBooks(); //calls save books
        var store2 = new BookStore(); //new bookstore

        // Assert
        Assert.Single(store2.Books); 
        Assert.Equal("Test Book", store2.Books[0].Title); 
    }
}
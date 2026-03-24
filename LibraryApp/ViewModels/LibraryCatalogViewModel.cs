using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LibraryApp.Models;
using LibraryApp.Repository;

//see books, select one and add/edit/delete it

namespace LibraryApp.ViewModels;

public partial class LibraryCatalogViewModel : ViewModelBase
{
    private readonly BookStore _bookStore;
    private readonly CatalogMode _catalogMode;
    private readonly Action _openAddBookEditor;
    private readonly Action<Book> _openEditBookEditor;

    //public properties
    //member sees Borrow
    public bool IsLibrarianMode => _catalogMode == CatalogMode.Librarian;
    //librarian sees add/edit/delete
    public bool IsMemberMode => _catalogMode == CatalogMode.Member;

    public ObservableCollection<Book> Books { get; } = new();

    [ObservableProperty]
    private Book? selectedBook;

    [ObservableProperty]
    private string searchText = "";
    partial void OnSearchTextChanged(string value) //ps generated partial method when property changes
    {
        LoadBooks();
    }

    [ObservableProperty]
    private string statusMessage = "";

    public LibraryCatalogViewModel(
        BookStore bookStore,
        CatalogMode catalogMode,
        Action openAddBookEditor,
        Action<Book> openEditBookEditor)
    {
        _bookStore = bookStore;
        _catalogMode = catalogMode;
        _openAddBookEditor = openAddBookEditor;
        _openEditBookEditor = openEditBookEditor;
        LoadBooks();
    }

    [RelayCommand]
    private void Borrow(Book bookToBorrow)
    {
        if (bookToBorrow != null)
        {
            bookToBorrow.IsAvailable = false;
            bookToBorrow.LoanedBy = UserStore.LoggedInUsername;

            if (_catalogMode == CatalogMode.Member)
            {
                Books.Remove(bookToBorrow);
            }

            _bookStore.SaveBooks();

            StatusMessage = $"You borrowed \"{bookToBorrow.Title}\" book.";
        }
    }

    [RelayCommand]
    private void DeleteSelectedBook()
    {
        if (SelectedBook == null)
        {
            return;
        }

        _bookStore.Books.Remove(SelectedBook);
        _bookStore.SaveBooks(); //saves to json
        LoadBooks(); //refreshes observable collection

        //updates/clears ui selection
        SelectedBook = null;
    }

    [RelayCommand]
    private void AddBook()
    {
        _openAddBookEditor();
    }

    [RelayCommand]
    private void EditSelectedBook()
    {
        if (SelectedBook == null)
        {
            return;
        }

        _openEditBookEditor(SelectedBook);
    }

    private void LoadBooks()
    {
        Books.Clear(); //remove the old list before rebuilding it

        foreach (var book in _bookStore.Books)
        {
            bool matchesRole = false;
            if (_catalogMode == CatalogMode.Member)
            {
                if (book.LoanedBy == "")
                {
                    matchesRole = true;
                }
            }
            else
            {
                matchesRole = true;
            }

            if (!matchesRole)
            {
                continue;
            }

            bool matchesSearch = true; //if search box is empty, everything passes the search test

            if (!string.IsNullOrWhiteSpace(SearchText))
            {
                string search = SearchText.ToLower();

                bool titleMatches = book.Title.ToLower().Contains(search);
                bool authorMatches = book.Author.ToLower().Contains(search);

                matchesSearch = titleMatches || authorMatches;
            }

            if (matchesSearch)
            {
                Books.Add(book);
            }
        }
    }
}
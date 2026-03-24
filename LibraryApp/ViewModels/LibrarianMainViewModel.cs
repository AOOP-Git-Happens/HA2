/*this is not how they asked us to call the views in assignment
but, i guess, can be used as a current page for librarian where he chooses
commands like full catalog, ActiveLoans (views) and maybe add/edit book
*/
using System;
using CommunityToolkit.Mvvm.ComponentModel;
using LibraryApp.Repository;
using LibraryApp.Models;

namespace LibraryApp.ViewModels;

public partial class LibrarianMainViewModel : ViewModelBase
{
    private readonly BookStore _bookStore = new BookStore();

    [ObservableProperty]
    private ViewModelBase? currentPage;

    public LibrarianMainViewModel()
    {
        //default page
        CurrentPage = new ActiveLoansViewModel(_bookStore);
    }

    public void ShowCatalog()
    {
        CurrentPage = new LibraryCatalogViewModel(_bookStore, CatalogMode.Librarian, ShowAddBookEditor, ShowEditBookEditor);
    }

    public void ShowActiveLoans()
    {
        CurrentPage = new ActiveLoansViewModel(_bookStore);
    }

    public void ShowAddBookEditor()
    {
        CurrentPage = new BookEditorViewModel(_bookStore, null, ShowCatalog);
    }

    public void ShowEditBookEditor(Book book)
    {
        CurrentPage = new BookEditorViewModel(_bookStore, book, ShowCatalog);
    }
}

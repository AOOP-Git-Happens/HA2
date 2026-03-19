/*this is not how they asked us to call the views in assignment
but, i guess, can be used as a current page for member where he chooses
commands LibraryCatalog or MyLoans pages (views)
*/
using System;
using CommunityToolkit.Mvvm.ComponentModel;
using LibraryApp.Repository;
using LibraryApp.Models;


namespace LibraryApp.ViewModels;

public partial class MemberMainViewModel : ViewModelBase
{
    private readonly BookStore _bookStore = new BookStore();

    [ObservableProperty]
    private ViewModelBase? currentPage;

    public MemberMainViewModel()
    {
        // default page
        CurrentPage = new LibraryCatalogViewModel(_bookStore, CatalogMode.Member);
    }

    public void ShowCatalog()
    {
        CurrentPage = new LibraryCatalogViewModel(_bookStore, CatalogMode.Member);
    }

    public void ShowMyLoans()
    {
        CurrentPage = new MyLoansViewModel(_bookStore);
    }
}

//current root screen, app startup state
//aka app coordinator
using CommunityToolkit.Mvvm.ComponentModel;
using System

namespace LibraryApp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private ViewModelBase _currentPage;

    //firstly shows login page 
    public MainWindowViewModel()
    {
        CurrentPage = new LoginViewModel(NavigateToMemberDashboard, NavigateToLibrarianDashboard);

        //for checking purposes, to see if these pages behave as intended
        //just uncomment the one you need to check
        //ofc we will delete this code and this comment from it when proper
        //navigation will be introduced
        
        //CurrentPage = new MemberMainViewModel();
        //CurrentPage = new LibrarianMainViewModel();
    }

    //after switches
    public void NavigateToMemberDashboard()
    {
        CurrentPage = new MemberMainViewModel();
    }

    public void NavigateToLibrarianDashboard()
    {
        CurrentPage = new LibrarianMainViewModel();
    }
}
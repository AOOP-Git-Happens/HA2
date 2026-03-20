using CommunityToolkit.Mvvm.ComponentModel;

namespace LibraryApp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private ViewModelBase _currentPage;

    public MainWindowViewModel()
    {
        CurrentPage = new LoginViewModel(); 
    }

    public void NavigateToMemberDashboard()
    {
        CurrentPage = new MemberMainViewModel();
    }

    public void NavigateToLibrarianDashboard()
    {
        CurrentPage = new LibrarianMainViewModel();
    }
}
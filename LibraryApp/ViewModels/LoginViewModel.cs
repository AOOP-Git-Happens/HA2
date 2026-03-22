using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LibraryApp.Repository;

namespace LibraryApp.ViewModels;

public partial class LoginViewModel : ViewModelBase
{
    private readonly Action _navigateToMember;
    private readonly Action _navigateToLibrarian;
    private readonly UserStore _userStore;
    
    [ObservableProperty]
    private string _username = "";

    [ObservableProperty]
    private string _password = "";
    
    public LoginViewModel(Action navigateToMember, Action navigateToLibrarian)
    {
        _navigateToMember = navigateToMember;
        _navigateToLibrarian = navigateToLibrarian;
        
        _userStore = new UserStore(); 
    }

    [RelayCommand]
    private void Login()
    {
        string role = _userStore.ValidateUser(Username, Password);
        
        if (role == "member")
        {
            UserStore.LoggedInUsername = Username;
            _navigateToMember();
        }
        else if (role == "librarian")
        {
            _navigateToLibrarian();
        }
        else
        {
            Console.WriteLine("Invalid username or password.");
        }
    }   
}
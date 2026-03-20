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
        
        // Create the store, which automatically loads the JSON file via its constructor
        _userStore = new UserStore(); 
    }

    [RelayCommand]
    private void Login()
    {
        // Ask the UserStore if the credentials are valid
        // Note: We use Username and Password here (the generated public properties)
        string role = _userStore.ValidateUser(Username, Password);
        
        if (role == "member")
        {
            _navigateToMember();
        }
        else if (role == "librarian")
        {
            _navigateToLibrarian();
        }
        else
        {
            // Optional: Handle what happens if the login fails
            Console.WriteLine("Invalid username or password.");
        }
    }   
}
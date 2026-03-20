using System;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Text.Json;
using System.IO;

namespace LibraryApp.ViewModels;

// what I am trying to do is that I activate this script if the login button is pressed, than it compares the model and sees if in the json file
// there is a user with that name and password. After that it checks with member type is this. This will link it t MemberMainView or LibarianMainView
public partial class LoginViewModel : ViewModelBase
{

    private readonly Action _navigateToMember;
    private readonly Action _navigateToLibrarian;
    
    [ObservableProperty]
    private string _username = "";

    [ObservableProperty]
    private string _password = "";
    
    public LoginViewModel(Action navigateToMember, Action navigateToLibrarian)
    {
        _navigateToMember = navigateToMember;
        _navigateToLibrarian = navigateToLibrarian;
    }

    [RelayCommand]
    private void Login()
    {
  
        string fileName = "login.json";
        string jsonString = File.ReadAllText(fileName);

        UserContainer? container = JsonSerializer.Deserialize<UserContainer>(jsonString);
        
        if(container.username == _username && container.password == _password)
        {
            //check if libarian or member
            if(container.role == "member")
            {
                //point to member site
                _navigateToMember();
                
            }
            else
            {
                // point to lib site
                _navigateToLibrarian();
            }
            
        }
        
    }   
    

}
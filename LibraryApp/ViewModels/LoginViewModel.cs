using System;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace LibraryApp.ViewModels;


// what I am trying to do is that I activate this script if the login button is pressed, than it compares the model and sees if in the json file
// there is a user with that name and password. After that it checks with member type is this. This will link it t MemberMainView or LibarianMainView
public partial class LoginViewModel : ViewModelBase
{

    [ObservableProperty]
    private string _username = "";

    [ObservableProperty]
    private string _password = "";
    

    [RelayCommand]
    private void Login()
    {
        
    }   
    

}

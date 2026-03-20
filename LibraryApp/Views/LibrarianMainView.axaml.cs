using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using LibraryApp.ViewModels;

namespace LibraryApp.Views;

public partial class LibrarianMainView : UserControl
{
    public LibrarianMainView()
    {
        InitializeComponent();
    }

    private void ShowActiveLoans(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (DataContext is LibrarianMainViewModel vm)
            vm.ShowActiveLoans();
    }

    private void ShowCatalog(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (DataContext is LibrarianMainViewModel vm)
            vm.ShowCatalog();
    }
}
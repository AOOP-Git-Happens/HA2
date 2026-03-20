using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using LibraryApp.ViewModels;

namespace LibraryApp.Views;

public partial class MemberMainView : UserControl
{
    public MemberMainView()
    {
        InitializeComponent();
    }

    private void ShowCatalog(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (DataContext is MemberMainViewModel vm)
            vm.ShowCatalog();
    }

    private void ShowLoans(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (DataContext is MemberMainViewModel vm)
            vm.ShowMyLoans();
    }
}
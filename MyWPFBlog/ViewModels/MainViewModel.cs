using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows;
using Wpf.Ui.Controls;
using MyWPFBlog.Views;
using System.Configuration;
using Wpf.Ui;
using CommunityToolkit.Mvvm.Input;

namespace MyWPFBlog.ViewModels
{
    public partial class MainViewModel : ObservableRecipient
    {
        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        [ObservableProperty]
        ObservableCollection<NavigationViewItem> _menuItems =
            [
                new NavigationViewItem("Home", SymbolRegular.AppGeneric24, typeof(DashboardPage)),
                new NavigationViewItem("Blogs", SymbolRegular.AppsListDetail24, typeof(BlogsPage)),
                new NavigationViewItem("Subscribers", SymbolRegular.BookContacts24, typeof(SubscribersPage)),
                new NavigationViewItem("Favorites", SymbolRegular.StarEmphasis24, typeof(FavoritesPage)),
            ];

        [ObservableProperty]
        ObservableCollection<NavigationViewItem> _footerMenuItems =
            [
               new NavigationViewItem("Settings", SymbolRegular.Settings24, typeof(SettingsPage))
            ];

        private INavigationService _navigationService;

        [RelayCommand]
        void Loaded()
        {
            _navigationService.Navigate(MenuItems.First().TargetPageType);
        }
    }
}

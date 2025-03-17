using MyWPFBlog.ViewModels;
using Wpf.Ui;
using Wpf.Ui.Abstractions.Controls;
using Wpf.Ui.Controls;

namespace MyWPFBlog.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : FluentWindow,INavigableView<LoginViewModel>
    {
        public LoginWindow(LoginViewModel vm,INavigationService navigationService)
        {
            InitializeComponent();
            navigationService.SetNavigationControl(NavigationView);
            ViewModel = vm;
            DataContext = ViewModel;
        }

        public LoginViewModel ViewModel { get; }
    }
      
}

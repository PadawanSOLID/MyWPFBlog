using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyWPFBlog.Views;
using System.Windows.Navigation;
using Wpf.Ui;

namespace MyWPFBlog.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private INavigationService _navigationService;

        public LoginViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        [RelayCommand]
        void Loaded()
        {
            CanSignIn(false);
        }

        private void CanSignIn(bool signIn)
        {
            _navigationService.Navigate(signIn ? typeof(SignInView) : typeof(SignUpView));
        }

        [RelayCommand]
        void SignUp()
        {
            _navigationService.Navigate(typeof(SignUpView));
        }

        [RelayCommand]
        void SignIn()
        {
            _navigationService.Navigate(typeof(SignInView));
        }

        [RelayCommand]
        void NavigateBack()
        {
            _navigationService.GoBack();
        }
    }
}

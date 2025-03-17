using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MyWPFBlog.Models;
using MyWPFBlog.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Wpf.Ui;

namespace MyWPFBlog.ViewModels
{
    public partial class SignInViewModel : ObservableObject
    {
        public SignInViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        [ObservableProperty]
        string email;
        [ObservableProperty]
        string password;

        private INavigationService _navigationService;

        [RelayCommand]
        void SignUp()
        {
            _navigationService.Navigate(typeof(SignUpView));
        }

        [RelayCommand]
        async Task SignIn()
        {
          

        }
    }
}

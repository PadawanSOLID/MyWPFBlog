using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using MyWPFBlog.Clients;
using MyWPFBlog.Messages;
using MyWPFBlog.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wpf.Ui;
using Wpf.Ui.Abstractions.Controls;
using static SkiaSharp.HarfBuzz.SKShaper;

namespace MyWPFBlog.ViewModels
{
    public partial class SignUpViewModel : ObservableValidator, INavigationAware
    {
        public SignUpViewModel(INavigationService navigationService, IUserClient userClient)
        {
            _navigationService = navigationService;
            _userClient = userClient;
        }

        [ObservableProperty]
        string email;

        partial void OnEmailChanged(string value)
        {
        }

        [ObservableProperty]
        string password;

        partial void OnPasswordChanged(string value)
        {
        }

        [ObservableProperty]
        string username;

        partial void OnUsernameChanged(string value)
        {
        }

        [ObservableProperty]
        string emailErrorMsg;
        [ObservableProperty]
        string passwordErrorMsg;
        [ObservableProperty]
        string usernameErrorMsg;
        [ObservableProperty]
        Visibility emailErrorVisibility = Visibility.Collapsed;
        [ObservableProperty]
        Visibility passwordErrorVisibility = Visibility.Collapsed;
        [ObservableProperty]
        Visibility usernameErrorVisibility = Visibility.Collapsed;

        private INavigationService _navigationService;
        private IUserClient _userClient;

        [RelayCommand]
        void SignIn()
        {
            _navigationService.Navigate(typeof(SignInView));
        }
        [RelayCommand]
        async Task SignUp()
        {
            try
            {
                var result = await _userClient.Create(Email, Password, Username);
                if (result)
                {
                    MessageBox.Show("Sign up successfully!");
                    _navigationService.Navigate(typeof(SignInView));
                    WeakReferenceMessenger.Default.Send(new WriterDTOMessage(Email));
                }
                else
                {
                    MessageBox.Show("Failed to create new account!");
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }

        public Task OnNavigatedFromAsync()
        {
            return Task.CompletedTask;
        }

        public Task OnNavigatedToAsync()
        {
            return Task.CompletedTask;
        }
    }
}

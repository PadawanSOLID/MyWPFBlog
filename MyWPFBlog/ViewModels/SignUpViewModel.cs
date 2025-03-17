using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using MyWPFBlog.Clients;
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
        public SignUpViewModel(INavigationService navigationService, IUserClient userClient, IServiceProvider serviceProvider)
        {
            _navigationService = navigationService;
            _userClient = userClient;
            _serviceProvider = serviceProvider;
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
        private IServiceProvider _serviceProvider;

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
                var res = await _userClient.GetWriters();
                if (res.Code != 200) return;
                        var result = await _userClient.Create(Email, Password, Username);
                if (result.Code == 200)
                {
                    App.Current.MainWindow.Close();
                    var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
                    mainWindow.ShowDialog();
                }
                else
                {
                    MessageBox.Show(result.Msg);
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

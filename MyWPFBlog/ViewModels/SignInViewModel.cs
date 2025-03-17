using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MyWPFBlog.Clients;
using MyWPFBlog.Messages;
using MyWPFBlog.Models;
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

namespace MyWPFBlog.ViewModels
{
    public partial class SignInViewModel : ObservableValidator, INavigationAware
    {
        public SignInViewModel(INavigationService navigationService, IAuthorizeClient authorizeClient, IServiceProvider serviceProvider)
        {
            _navigationService = navigationService;
            _authorizeClient = authorizeClient;
            _serviceProvider = serviceProvider;
            WeakReferenceMessenger.Default.Register<WriterDTOMessage>(this, (o, m) =>
            {
                Email = m.Value;
            });
        }

        [ObservableProperty]
        string email;
        [ObservableProperty]
        string password;

        private INavigationService _navigationService;
        private IAuthorizeClient _authorizeClient;
        private IServiceProvider _serviceProvider;

        [RelayCommand]
        void SignUp()
        {
            _navigationService.Navigate(typeof(SignUpView));
        }

        [RelayCommand]
        async Task SignIn()
        {
            try
            {
                var token = await _authorizeClient.Login(Email, Password);
                if (token != null)
                {
                    App.Current.MainWindow.Close();
                    var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
                    mainWindow.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Login failed!");
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }

        public Task OnNavigatedToAsync()
        {
            return Task.CompletedTask;
        }

        public Task OnNavigatedFromAsync()
        {
            return Task.CompletedTask;
        }
    }
}

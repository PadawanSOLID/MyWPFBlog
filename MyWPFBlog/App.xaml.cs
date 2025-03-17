using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyWPFBlog.Clients;
using MyWPFBlog.Services;
using MyWPFBlog.ViewModels;
using MyWPFBlog.Views;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;
using Wpf.Ui;
using Wpf.Ui.Abstractions;

namespace MyWPFBlog
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static readonly IHost _host = Host.CreateDefaultBuilder().ConfigureAppConfiguration(c =>
        {
            c.AddJsonFile(Path.Combine(Environment.CurrentDirectory,"appsettings.json"));
            _ = c.SetBasePath(AppContext.BaseDirectory);
        })
            .ConfigureServices( (_ , services) =>
            {
                services.AddSingleton<INavigationViewPageProvider,DependencyInjectionNavigationViewPageProvider>();
                services.AddHostedService<ApplicationHostService>();
                services.AddSingleton<MainWindow>();
                services.AddSingleton<MainViewModel>();
                services.AddSingleton<LoginWindow>();
                services.AddSingleton<LoginViewModel>();
                services.AddSingleton<SignInView>();
                services.AddSingleton<SignInViewModel>();
                services.AddSingleton<SignUpView>();
                services.AddSingleton<SignUpViewModel>();
                
                services.AddSingleton<DashboardPage>();
                services.AddSingleton<DashboardViewModel>();
                services.AddSingleton<BlogsPage>();
                services.AddSingleton<BlogsViewModel>();
                services.AddSingleton<FavoritesPage>();
                services.AddSingleton<FavoritesViewModel>();
                services.AddSingleton<SubscribersPage>();
                services.AddSingleton<SubscribersViewModel>();
                services.AddSingleton<SettingsPage>();
                services.AddSingleton<SettingsViewModel>();
                services.AddSingleton<INavigationService, NavigationService>();

                services.AddScoped<IUserClient, UserClient>();
                services.AddScoped<IAuthorizeClient, AuthorizeClient>();
            }).Build();

        private void OnStartup(object sender, StartupEventArgs e)
        {
            _host.Start();
        }
    }

}

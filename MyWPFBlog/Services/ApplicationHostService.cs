using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyWPFBlog.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyWPFBlog.Services
{
    public class ApplicationHostService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public ApplicationHostService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return HandleActivationAsync();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Creates main window during activation.
        /// </summary>
        private Task HandleActivationAsync()
        {
            if (Application.Current.Windows.OfType<LoginWindow>().Any())
            {
                return Task.CompletedTask;
            }

            var loginWindow = _serviceProvider.GetRequiredService<LoginWindow>();
            loginWindow?.Show();

            return Task.CompletedTask;
        }

    }

}

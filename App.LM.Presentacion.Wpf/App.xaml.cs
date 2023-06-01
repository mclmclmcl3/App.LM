using MiApp.LM.Presentacion.Wpf.ViewModels;
using MiApp.LM.Presentacion.Wpf.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MiApp.LM.Presentacion.Wpf
{
    public partial class App : Application
    {
        public static IHost AppHost { get; private set; }
        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {

                    services.AddSingleton<MainWindow>();
                    services.AddSingleton<MainWindowViewModel>();

                }).Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost.StartAsync();
            var main = AppHost.Services.GetRequiredService<MainWindow>();
            main.DataContext = AppHost.Services.GetRequiredService<MainWindowViewModel>();
            main.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost.StopAsync();
            base.OnExit(e);
        }
    }
}

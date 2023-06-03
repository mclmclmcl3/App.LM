using MiApp.LM.Presentacion.Wpf.Controller;
using MiApp.LM.Presentacion.Wpf.MVVM.Navegacion;
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

                    services.AddSingleton<MonoPantallaView>();
                    services.AddSingleton<MonoPantallaViewModel>();

                    services.AddSingleton<MonoPantallaEstadisticasView>();
                    services.AddSingleton<MonoPantallaEstadisticasViewModels>();

                    services.AddSingleton<MonoPantallaListadoView>();
                    services.AddSingleton<MonoPantallaListadoViewModels>();

                    services.AddSingleton<MonoPantallaOfertasView>();
                    services.AddSingleton<MonoPantallaOfertasViewModels>();

                    services.AddSingleton<MonoPantallaPedidosView>();
                    services.AddSingleton<MonoPantallaPedidosViewModels>();

                    services.AddSingleton<MonoPantallaProyectosView>();
                    services.AddSingleton<MonoPantallaProyectosLateralView>();
                    services.AddSingleton<MonoPantallaProyectosPrincipalView>();
                    services.AddSingleton<MonoPantallaProyectosViewModels>();

                    services.AddSingleton<NavigationStore>();

                    services.AddSingleton<IProyectoController, ProyectoController>();
                    services.AddSingleton<IElementoController, ElementoController>();

                }).Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost.StartAsync();

            //    await AppHost.StartAsync();
            //    var main = AppHost.Services.GetRequiredService<MainWindow>();
            //    main.DataContext = AppHost.Services.GetRequiredService<MainWindowViewModel>();
            //    main.Show();

            //var Proyectos = AppHost.Services.GetRequiredService<MonoPantallaProyectosView>();
            //var Proyecotslateral = AppHost.Services.GetRequiredService<MonoPantallaProyectosLateralView>();
            //var ProyectosPrincipal = AppHost.Services.GetRequiredService<MonoPantallaProyectosPrincipalView>();

            //Proyectos.DataContext = AppHost.Services.GetRequiredService<MonoPantallaProyectosViewModels>();
            //Proyecotslateral.DataContext = AppHost.Services.GetRequiredService<MonoPantallaProyectosViewModels>();
            //ProyectosPrincipal.DataContext = AppHost.Services.GetRequiredService<MonoPantallaProyectosViewModels>();


            var main = AppHost.Services.GetRequiredService<MonoPantallaView>();
            main.DataContext = AppHost.Services.GetRequiredService<MonoPantallaViewModel>();
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

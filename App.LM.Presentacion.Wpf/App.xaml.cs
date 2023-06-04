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
                    services.AddSingleton<InicioView>();
                    services.AddSingleton<InicioViewModel>();

                    services.AddSingleton<MonoPantallaEstadisticasView>();
                    services.AddSingleton<EstadisticasViewModels>();

                    services.AddSingleton<ListadoView>();
                    services.AddSingleton<ListadoViewModels>();

                    services.AddSingleton<OfertasView>();
                    services.AddSingleton<OfertasViewModels>();

                    services.AddSingleton<PedidosView>();
                    services.AddSingleton<PedidosViewModels>();

                    services.AddSingleton<ProyectosView>();
                    services.AddSingleton<ProyectosLateralView>();
                    services.AddSingleton<ProyectosPrincipalView>();
                    services.AddSingleton<ProyectosViewModels>();

                    services.AddSingleton<NavigationStore>();

                    services.AddSingleton<IProyectoController, ProyectoController>();
                    services.AddSingleton<IElementoController, ElementoController>();

                }).Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost.StartAsync();

            //var Proyectos = AppHost.Services.GetRequiredService<MonoPantallaProyectosView>();
            //var Proyecotslateral = AppHost.Services.GetRequiredService<MonoPantallaProyectosLateralView>();
            //var ProyectosPrincipal = AppHost.Services.GetRequiredService<MonoPantallaProyectosPrincipalView>();

            //Proyectos.DataContext = AppHost.Services.GetRequiredService<MonoPantallaProyectosViewModels>();
            //Proyecotslateral.DataContext = AppHost.Services.GetRequiredService<MonoPantallaProyectosViewModels>();
            //ProyectosPrincipal.DataContext = AppHost.Services.GetRequiredService<MonoPantallaProyectosViewModels>();


            var main = AppHost.Services.GetRequiredService<InicioView>();
            main.DataContext = AppHost.Services.GetRequiredService<InicioViewModel>();
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

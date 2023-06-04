﻿using MiApp.LM.Presentacion.Wpf.Controller;
using MiApp.LM.Presentacion.Wpf.Mensajeria;
using MiApp.LM.Presentacion.Wpf.Models;
using MiApp.LM.Presentacion.Wpf.MVVM.Navegacion;
using MiApp.LM.Presentacion.Wpf.Resources.Controles;
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

                    services.AddSingleton<EstadisticasView>();
                    services.AddSingleton<EstadisticasViewModel>();

                    services.AddSingleton<ListadoView>();
                    services.AddSingleton<ListadoViewModel>();

                    services.AddSingleton<OfertasView>();
                    services.AddSingleton<OfertasViewModel>();

                    services.AddSingleton<PedidosView>();
                    services.AddSingleton<PedidosViewModel>();

                    services.AddSingleton<ProyectosView>();
                    services.AddSingleton<ProyectosLateralView>();
                    services.AddSingleton<ProyectosPrincipalView>();
                    services.AddSingleton<ProyectosViewModel>();

                    services.AddSingleton<PiePagina>();
                    services.AddSingleton<PiePaginaViewModel>();
                    services.AddSingleton<MensajePiePagina>();

                    services.AddSingleton<NavigationStore>();
                    services.AddSingleton<EventUpdate>();

                    services.AddSingleton<IProyectoController, ProyectoController>();
                    services.AddSingleton<IElementoController, ElementoController>();

                }).Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost.StartAsync();

            var pie = AppHost.Services.GetRequiredService<PiePaginaViewModel>();
            var eventUpdate = AppHost.Services.GetRequiredService<EventUpdate>();
            pie.EventUpdate = eventUpdate;

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

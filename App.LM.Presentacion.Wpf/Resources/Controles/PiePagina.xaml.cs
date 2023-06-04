using MiApp.LM.Presentacion.Wpf.Models;
using MiApp.LM.Presentacion.Wpf.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace MiApp.LM.Presentacion.Wpf.Resources.Controles
{
    /// <summary>
    /// Lógica de interacción para PiePagina.xaml
    /// </summary>
    public partial class PiePagina : UserControl
    {
        public PiePaginaViewModel _viewModel;

        public PiePagina()
        {
            InitializeComponent();
            this.DataContext = _viewModel = App.AppHost.Services.GetService<PiePaginaViewModel>();
        }
    }
}


using MiApp.LM.Presentacion.Wpf.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace MiApp.LM.Presentacion.Wpf.Views
{
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

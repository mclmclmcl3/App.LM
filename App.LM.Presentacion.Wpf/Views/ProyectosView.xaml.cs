using MiApp.LM.Presentacion.Wpf.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace MiApp.LM.Presentacion.Wpf.Views
{
    public partial class ProyectosView : UserControl
    {
        private ProyectosViewModel _viewModel;
        public ProyectosView()
        {
            InitializeComponent();
            this.DataContext = _viewModel = App.AppHost.Services.GetRequiredService<ProyectosViewModel>(); 
        }

        private void Loader(object sender, System.Windows.RoutedEventArgs e)
        {
            _viewModel.ActualizarMensajes();
        }
    }
}

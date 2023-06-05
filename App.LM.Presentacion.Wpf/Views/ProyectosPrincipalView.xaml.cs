using MiApp.LM.Presentacion.Wpf.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace MiApp.LM.Presentacion.Wpf.Views
{
    public partial class ProyectosPrincipalView : UserControl
    {
        private ProyectosViewModel _viewmodel;

        public ProyectosPrincipalView()
        {
            InitializeComponent();
            this.DataContext = _viewmodel = App.AppHost.Services.GetRequiredService<ProyectosViewModel>();
        }

        private void Loader(object sender, System.Windows.RoutedEventArgs e)
        {
            _viewmodel.ActualizarMensajes();
        }
    }
}

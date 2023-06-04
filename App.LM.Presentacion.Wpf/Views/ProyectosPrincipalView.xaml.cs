using MiApp.LM.Presentacion.Wpf.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace MiApp.LM.Presentacion.Wpf.Views
{
    public partial class ProyectosPrincipalView : UserControl
    {
        private ProyectosViewModels _viewmodel;

        public ProyectosPrincipalView()
        {
            InitializeComponent();
            this.DataContext = _viewmodel = App.AppHost.Services.GetRequiredService<ProyectosViewModels>();
        }
    }
}

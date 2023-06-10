using MiApp.LM.Presentacion.Wpf.ViewModels.Modales;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace MiApp.LM.Presentacion.Wpf.Views.Modals.ModalCargaInventor
{
    public partial class CargarInventorView : Window
    {
        private CargarInventorViewModel viewmodel;
        public CargarInventorView()
        {
            InitializeComponent();
            this.DataContext = viewmodel = App.AppHost.Services.GetRequiredService<CargarInventorViewModel>();
        }

    }
}

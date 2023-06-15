using MiApp.LM.Presentacion.Wpf.ViewModels.Modales;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MiApp.LM.Presentacion.Wpf.Views.Modals.ModalCargaInventor
{
    /// <summary>
    /// Lógica de interacción para CargarInventorCargaExcelView.xaml
    /// </summary>
    public partial class CargarInventorCargaExcelView : UserControl
    {
        private CargarInventorViewModel viewmodel;

        public CargarInventorCargaExcelView()
        {
            InitializeComponent();
            this.DataContext = viewmodel = App.AppHost.Services.GetRequiredService<CargarInventorViewModel>();
        }
    }
}

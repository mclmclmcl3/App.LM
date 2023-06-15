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
    public partial class CargarInventorColumnasView : UserControl
    {
        private CargarInventorViewModel viewmodel;

        public CargarInventorColumnasView()
        {
            InitializeComponent();
            this.DataContext = viewmodel = App.AppHost.Services.GetRequiredService<CargarInventorViewModel>();

        }


        private void Combo_Elemento(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Combo_Cantidad(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Combo_Nombre(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Combo_Descripcion(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Combo_CantUnidades(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Combo_Material(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Combo_CantElementos(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Combo_Masa(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Combo_Archivo(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Combo_Proveedor(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Combo_Tipo(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

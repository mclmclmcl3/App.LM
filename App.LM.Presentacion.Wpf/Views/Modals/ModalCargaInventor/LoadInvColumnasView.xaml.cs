using MiApp.LM.Presentacion.Wpf.ViewModels.Modales;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace MiApp.LM.Presentacion.Wpf.Views.Modals.ModalCargaInventor
{
    public partial class LoadInvColumnasView : UserControl
    {
        private LoadInvColumnasViewModels viewmodel;

        public LoadInvColumnasView()
        {
            InitializeComponent();
            this.DataContext = viewmodel = App.AppHost.Services.GetRequiredService<LoadInvColumnasViewModels>();

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

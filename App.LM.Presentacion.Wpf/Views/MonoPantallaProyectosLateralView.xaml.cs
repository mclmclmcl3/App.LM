using MiApp.LM.Dominio.Models;
using MiApp.LM.Presentacion.Wpf.ViewModels;
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

namespace MiApp.LM.Presentacion.Wpf.Views
{
    /// <summary>
    /// Lógica de interacción para MonoPantallaProyectosLateralView.xaml
    /// </summary>
    public partial class MonoPantallaProyectosLateralView : UserControl
    {
        private MonoPantallaProyectosViewModels viewmodel;
        public MonoPantallaProyectosLateralView()
        {
            InitializeComponent();
            this.DataContext = viewmodel = App.AppHost.Services.GetService<MonoPantallaProyectosViewModels>();
        }

        private void On_Loeader(object sender, RoutedEventArgs e)
        {
            var cant = LV_Proyectos.Items;
            if (cant.Count > 0)
                LV_Proyectos.SelectedItem = viewmodel.ListaProyectos.IndexOf(viewmodel.Proyecto);
        }

        private void CambioListBox(object sender, TextChangedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(LV_Proyectos.ItemsSource);

            view.Filter = new Predicate<object>(item => PreFilterName(item) && PreFilterDescripcion(item));

            CollectionViewSource.GetDefaultView(LV_Proyectos.ItemsSource).Refresh();

        }

        private bool PreFilterName(object item)
        {
            if (string.IsNullOrEmpty(txtContiene.Text)) return true;
            else return ((item as Proyecto).Nombre.IndexOf(txtContiene.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        private bool PreFilterDescripcion(object item)
        {
            if (string.IsNullOrEmpty(txtContieneDescripcion.Text)) return true;
            else return ((item as Proyecto).Descripcion.IndexOf(txtContieneDescripcion.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }
    }
}

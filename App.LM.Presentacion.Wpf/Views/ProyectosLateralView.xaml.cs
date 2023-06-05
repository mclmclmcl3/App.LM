using MiApp.LM.Dominio.Models;
using MiApp.LM.Presentacion.Wpf.Models;
using MiApp.LM.Presentacion.Wpf.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace MiApp.LM.Presentacion.Wpf.Views
{
    public partial class ProyectosLateralView : UserControl
    {
        private ProyectosViewModel _viewmodel;
        public ProyectosLateralView()
        {
            InitializeComponent();
            this.DataContext = _viewmodel = App.AppHost.Services.GetService<ProyectosViewModel>();
        }

        private void On_Loeader(object sender, RoutedEventArgs e)
        {
            var cant = LV_Proyectos.Items;
            if (cant.Count > 0)
                LV_Proyectos.SelectedItem = _viewmodel.ListaProyectos.IndexOf(_viewmodel.Proyecto);
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


        private void LV_Proyectos_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == Key.Escape)
            {
                ProyectoActivo.GetInstancia.Proyecto = null;
                LV_Proyectos.SelectedItems.Clear();
                Filtro.Focus();
                _viewmodel.Proyecto = null;
                
            }
        }
    }
}

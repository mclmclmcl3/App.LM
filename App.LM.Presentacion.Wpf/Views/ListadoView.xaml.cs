using MiApp.LM.Aplicacion.Wpf.Models;
using MiApp.LM.Presentacion.Wpf.Models;
using MiApp.LM.Presentacion.Wpf.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Controls;
using Telerik.Windows.Controls;

namespace MiApp.LM.Presentacion.Wpf.Views
{
    public partial class ListadoView : UserControl
    {
        private ListadoViewModel _viewModel;
        public ListadoView()
        {
            InitializeComponent();
            this.DataContext = _viewModel = App.AppHost.Services.GetRequiredService<ListadoViewModel>();
            arbol.SelectionChanged += arbol_selectionChanged;
        }

        private void arbol_selectionChanged(object sender, SelectionChangeEventArgs e)
        {
            if(arbol.SelectedItem!=null)
            {
                var nombre = (arbol.SelectedItem as ArbolElemento).Elemento.Nombre;
                _viewModel.SelectionCommand.Execute(nombre);
            }
        }

        private void Loader(object sender, System.Windows.RoutedEventArgs e)
        {
            arbol.SelectedItem = null;
            _viewModel.ActualizarMensajes();
        }
    }
}

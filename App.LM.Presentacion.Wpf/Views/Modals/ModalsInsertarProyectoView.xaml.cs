using MiApp.LM.Dominio.Models;
using MiApp.LM.Presentacion.Wpf.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace MiApp.LM.Presentacion.Wpf.Views.Modals
{
    public partial class ModalsInsertarProyectoView : Window, INotifyPropertyChanged
    {
        private readonly ProyectosViewModels _viewModel;
        public event PropertyChangedEventHandler? PropertyChanged;

        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; OnPropertyChange(nameof(Nombre)); }
        }

        private string descripcion;
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; OnPropertyChange(nameof(Descripcion)); }
        }

        public ModalsInsertarProyectoView(ProyectosViewModels monoPantallaProyectosViewModels)
        {
            InitializeComponent();
            this._viewModel = monoPantallaProyectosViewModels;
        }

        private void Btn_Cancelar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Proyecto proyecto = new Proyecto();
            proyecto.Nombre = Nombre;
            proyecto.Descripcion = Descripcion;


            if (!_viewModel.PController.Existe(proyecto.Nombre))
            {
                _viewModel.PController.Insertar(proyecto);
                _viewModel.FiltroLista();

                _viewModel.ListaProyectos.Clear();
                //inicioViewModel.ListaProyectos.AddRange(new ObservableCollection<Proyecto>(inicioViewModel.PController.GetAll().OrderBy(x=>x.Nombre)));
                foreach (var proy in _viewModel.PController.GetAll().OrderBy(x => x.Nombre))
                {
                    _viewModel.ListaProyectos.Add(proy);
                }
                this.Close();

            }
        }

        public void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

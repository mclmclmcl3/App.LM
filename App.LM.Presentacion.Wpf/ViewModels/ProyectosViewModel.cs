using MiApp.LM.Dominio.Models;
using MiApp.LM.Presentacion.Wpf.Controller;
using MiApp.LM.Presentacion.Wpf.Mensajeria;
using MiApp.LM.Presentacion.Wpf.Models;
using MiApp.LM.Presentacion.Wpf.MVVM.Navegacion;
using MiApp.LM.Presentacion.Wpf.MVVM.Navegacion.Modals;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Telerik.Windows.Controls;
using ViewModelBase = MiApp.LM.Presentacion.Wpf.MVVM.ViewModelBase;

namespace MiApp.LM.Presentacion.Wpf.ViewModels
{
    public class ProyectosViewModel : ViewModelBase
    {
        private Proyecto _proyecto;
        private ObservableCollection<Proyecto> _listaProyectos = new ObservableCollection<Proyecto>();
        private List<Elemento> _listaElementos;
        public IProyectoController PController = new ProyectoController();
        public IElementoController EController = new ElementoController();
        private Elemento _elemento;
        private string _visibilidad = "Hidden";
        private EventUpdate eventUpdate;
        public NavigationStore NavigationStore { get; set; }

        public Proyecto Proyecto
        {
            get { return _proyecto; }
            set
            {
                _proyecto = value;
                OnPropertyChange(nameof(Proyecto));
                if (Proyecto != null)
                {
                    Visibilidad = "Visible";
                    ProyectoActivo.GetInstancia.Proyecto = value;

                    eventUpdate.MensajePiePagina =
                        new MensajePiePagina()
                        {
                            Mensaje = "Proyecto Seleccionado",
                            ColorBg = Colores.Primary,
                            ColorFg = Colores.Blanco
                        };
                }
                else
                {
                    Visibilidad = "Hidden";
                    eventUpdate.MensajePiePagina =
                        new MensajePiePagina()
                        {
                            Mensaje = "No hay Proyecto Seleccionado",
                            ColorBg = Colores.Warning,
                            ColorFg = Colores.Blanco
                        };
                }
                eventUpdate.PublishParameter();
                FiltroLista();
            }
        }
        public string Visibilidad
        {
            get => _visibilidad;
            set
            {
                _visibilidad = value;
                OnPropertyChange();
            }
        }
        public ObservableCollection<Proyecto> ListaProyectos
        {
            get { return _listaProyectos; }
            set { _listaProyectos = value; }
        }
        public List<Elemento> ListaElementos
        {
            get { return _listaElementos; }
            set
            {
                _listaElementos = value;
                OnPropertyChange(nameof(ListaElementos));
            }
        }
        public Elemento Elemento
        {
            get { return _elemento; }
            set { _elemento = value; OnPropertyChange(nameof(Elemento)); }
        }

        public ICommand InsertarProyectoCommand { get; }
        public ICommand ModificarProyectoCommand { get; }
        public ICommand BorrarProyectoCommand { get; }

        public ProyectosViewModel(NavigationStore navigationStore, EventUpdate eventUpdate)
        {
            ListaProyectos = new ObservableCollection<Proyecto>();
            InsertarProyectoCommand = new NavegacionInsertarProyectoCommand(this);
            ModificarProyectoCommand = new NavegacionModificarProyectoCommand(this);
            BorrarProyectoCommand = new DelegateCommand(BorrarProyecto);

            this.eventUpdate = eventUpdate;
            Actualizar();
            NavigationStore = navigationStore;
        }

        public void Actualizar()
        {
            ListaProyectos.Clear();
            foreach (var proyecto in PController.GetAll().OrderBy(x => x.Nombre))
            {
                this.ListaProyectos.Add(proyecto);
            }
        }

        private void BorrarProyecto(object obj)
        {
            if (Proyecto != null)
            {
                string message = $"Estas seguro que quieres borrar el proyecto {Proyecto.Nombre}";
                string caption = "CONFIRMACION";
                var result = MessageBox.Show(message, caption, MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    PController.Remove(Proyecto);
                    ListaProyectos.Clear();
                    //ListaProyectos.AddRange(new ObservableCollection<Proyecto>(PController.GetAll().OrderBy(x => x.Nombre)));
                    foreach (var proyecto in PController.GetAll().OrderBy(x => x.Nombre))
                    {
                        ListaProyectos.Add(proyecto);
                    }
                }
            }
        }

        public void FiltroLista()
        {
            if (Proyecto == null)
                ListaElementos = EController.GetAllByProyecto(-1);
            else
                ListaElementos = EController.GetAllByProyecto(Proyecto.ProyectoId);
        }
    }
}

using MiApp.LM.Aplicacion.Wpf.Models;
using MiApp.LM.Dominio.Models;
using MiApp.LM.Presentacion.Wpf.Controller;
using MiApp.LM.Presentacion.Wpf.Helpper;
using MiApp.LM.Presentacion.Wpf.Mensajeria;
using MiApp.LM.Presentacion.Wpf.Models;
using MiApp.LM.Presentacion.Wpf.MVVM;
using MiApp.LM.Presentacion.Wpf.MVVM.Navegacion;
using MiApp.LM.Presentacion.Wpf.MVVM.Navegacion.Modals;
using MiApp.LM.Presentacion.Wpf.Views.Modals;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Telerik.Windows.Controls;
using ViewModelBase = MiApp.LM.Presentacion.Wpf.MVVM.ViewModelBase;

namespace MiApp.LM.Presentacion.Wpf.ViewModels
{
    public class ListadoViewModel : ViewModelBase
    {

        private EventUpdate eventUpdate;
        private IElementoController elementoController;
        private Elemento elemento;
        private ObservableCollection<ArbolElemento> arbol;
        private ObservableCollection<Elemento> elementos;
        private ArbolElemento seleccionArbol = null;
        private readonly NavigationStore navigationStore;


        public ArbolElemento SeleccionArbol
        {
            get { return seleccionArbol; }
            set
            {
                seleccionArbol = value;
                OnPropertyChanged();
                ActualizarMensajes();
            }
        }
        public Elemento Elemento { get { return elemento; } set { elemento = value; OnPropertyChanged(); } }
        public ObservableCollection<Elemento> Elementos { get { return elementos; } set { elementos = value; } }
        public ObservableCollection<ArbolElemento> Arbol
        {
            get { return arbol; }
            set { arbol = value; OnPropertyChanged(); }
        }


        public ICommand SelectionCommand { get; set; }

        public ICommand InventorCommand { get; set; }
        public ICommand MaestroCommand { get; set; }
        public ICommand NavisionCommand { get; set; }

        public ListadoViewModel(NavigationStore navigationStore, EventUpdate eventUpdate)
        {
            this.navigationStore = navigationStore;
            this.eventUpdate = eventUpdate;
            this.elementoController = new ElementoController();
            this.Elementos = new ObservableCollection<Elemento>(this.elementoController.GetAll());

            SelectionCommand = new DelegateCommand(SeleccionArbolCommand);

            InventorCommand = new NavegacionCargarInventorCommand(this);
            MaestroCommand = new DelegateCommand(AbrirMaestro);
            NavisionCommand = new DelegateCommand(AbrirNavision);

            Arbol = ArbolTreeView.ConstruirArbol(Arbol, Elementos);
        }

        private void AbrirNavision(object obj)
        {
            throw new NotImplementedException();
        }

        private void AbrirMaestro(object obj)
        {
            throw new NotImplementedException();
        }


        private void SeleccionArbolCommand(object t)
        {
            var nombre = t as string;
            //MessageBox.Show($"El elemento seleccionado es: {t}");
        }       
        public void ActualizarMensajes()
        {
            if (seleccionArbol != null)
            {
                eventUpdate.MensajePiePagina =
                    new MensajePiePagina()
                    {
                        Mensaje = $"Seleccionado el elemento {seleccionArbol.Elemento.Nombre}",
                        ColorBg = Colores.Primary,
                        ColorFg = Colores.Blanco
                    };
            }
            else
            {
                eventUpdate.MensajePiePagina =
                    new MensajePiePagina()
                    {
                        Mensaje = $"No hay elemento selecdcionado",
                        ColorBg = Colores.Success,
                        ColorFg = Colores.Blanco
                    };
            }

            eventUpdate.PublishParameter();
        }
    }
}

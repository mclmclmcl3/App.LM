using MiApp.LM.Presentacion.Wpf.Mensajeria;
using MiApp.LM.Presentacion.Wpf.Models;
using MiApp.LM.Presentacion.Wpf.MVVM;
using System;

namespace MiApp.LM.Presentacion.Wpf.ViewModels
{
    public class PiePaginaViewModel : ViewModelBase
    {
        private string nombre;
        private string mensaje;
        private string colorBg;
        private string colorFg;
        private EventUpdate eventUpdate;
        public EventUpdate EventUpdate
        {
            get { return eventUpdate; }
            set
            {
                eventUpdate = value;
                OnPropertyChange();
                eventUpdate.ParameterPassed += Actualizar;
            }
        }

        public string Nombre
        {
            get => nombre;
            set { nombre = value; OnPropertyChange(); }
        }
        public string Mensaje
        {
            get => mensaje;
            set { mensaje = value; OnPropertyChange(); }
        }
        public string ColorBg
        {
            get => colorBg;
            set { colorBg = value; OnPropertyChange(); }
        }
        public string ColorFg
        {
            get => colorFg;
            set { colorFg = value; OnPropertyChange(); }
        }

        private void Actualizar()
        {
            if (ProyectoActivo.GetInstancia.Proyecto == null) Nombre = "s/c";
            else Nombre = ProyectoActivo.GetInstancia.Proyecto.Nombre;

            Mensaje = eventUpdate.MensajePiePagina.Mensaje;
            ColorBg = eventUpdate.MensajePiePagina.ColorBg.GetDescription();
            ColorFg = eventUpdate.MensajePiePagina.ColorFg.GetDescription();
        }
    }
}

using MiApp.LM.Dominio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.LM.Presentacion.Wpf.Models
{
    public class ProyectoActivo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private static ProyectoActivo _proyectoActivo = null;
        private ProyectoActivo() { }

        private Proyecto _proyecto = null;
        public Proyecto Proyecto
        {
            get { return _proyecto; }
            set
            {
                _proyecto = value;
                OnPropertyChanged();
            }
        }
        public static ProyectoActivo GetInstancia
        {
            get
            {
                if (_proyectoActivo == null)
                    _proyectoActivo = new ProyectoActivo();
                return _proyectoActivo;
            }
        }
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

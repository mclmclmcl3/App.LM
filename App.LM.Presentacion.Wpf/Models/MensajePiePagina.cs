using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MiApp.LM.Presentacion.Wpf.Models
{
    public class MensajePiePagina : INotifyPropertyChanged
    {
        private string mensaje;
        private Colores colorBg;
        private Colores colorFg;

        public string Mensaje
        {
            get => mensaje;
            set { mensaje = value; OnPropertyChanged(); }
        }
        public Colores ColorFg
        {
            get => colorFg;
            set { colorFg = value; OnPropertyChanged(); }
        }
        public Colores ColorBg
        {
            get => colorBg;
            set { colorBg = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

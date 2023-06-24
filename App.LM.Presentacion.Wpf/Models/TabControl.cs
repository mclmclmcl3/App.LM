using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.LM.Presentacion.Wpf.Models
{
    public class TabControl : INotifyPropertyChanged
    {
        // Instrucciones
        // Carga Excel
        // Configurar Columnas
        // Asociar Perfiles

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int tab = 0;
        public int Tab
        {
            get { return tab; }
            set { tab = value; OnPropertyChanged(nameof(Tab)); }
        }

        private string vExcel = Visibilidad.Collapsed.ToString();
        public string VExcel
        {
            get
            {
                if (vExcel == Visibilidad.Visible.ToString()) Tab = 1;
                return vExcel;
            }
            set { vExcel = value; OnPropertyChanged(nameof(VExcel)); }
        }

        private string vColumnas = Visibilidad.Collapsed.ToString();
        public string VColumnas
        {
            get
            {
                if (vColumnas == Visibilidad.Visible.ToString()) Tab = 2;
                return vColumnas;
            }
            set { vColumnas = value; OnPropertyChanged(nameof(VColumnas)); }
        }

        private string vPerfiles = Visibilidad.Collapsed.ToString();
        public string VPerfiles
        {
            get
            {
                if (vExcel == Visibilidad.Visible.ToString()) Tab = 3;
                return vPerfiles;
            }
            set { vPerfiles = value; OnPropertyChanged(nameof(VPerfiles)); }
        }
    }

    public enum Visibilidad { Collapsed, Visible }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Diagrams.Core;

namespace MiApp.LM.Presentacion.Wpf.Models
{
    public class CombosColumnasExcel : IPropertyChanged
    {

        private string comboElemento = string.Empty;
        public string ComboElemento
        {
            get { return comboElemento; }
            set { comboElemento = value; OnPropertyChanged(); }
        }

        private string comboCantidad = string.Empty;
        public string ComboCantidad
        {
            get { return comboCantidad; }
            set { comboCantidad = value; OnPropertyChanged(); }
        }

        private string comboNombre = string.Empty;
        public string ComboNombre
        {
            get { return comboNombre; }
            set { comboNombre = value; OnPropertyChanged(); }
        }

        private string comboDescripcion = string.Empty;
        public string ComboDescripcion
        {
            get { return comboDescripcion; }
            set { comboDescripcion = value; OnPropertyChanged(); }
        }

        private string comboCantidadUnidades = string.Empty;
        public string ComboCantidadUnidades
        {
            get { return comboCantidadUnidades; }
            set { comboCantidadUnidades = value; OnPropertyChanged(); }
        }

        private string comboMaterial = string.Empty;
        public string ComboMaterial
        {
            get { return comboMaterial; }
            set { comboMaterial = value; OnPropertyChanged(); }
        }

        private string comboCantidadElementos = string.Empty;
        public string ComboCantidadElementos
        {
            get { return comboCantidadElementos; }
            set { comboCantidadElementos = value; OnPropertyChanged(); }
        }

        private string comboMasa = string.Empty;
        public string ComboMasa
        {
            get { return comboMasa; }
            set { comboMasa = value; OnPropertyChanged(); }
        }

        private string comboArchivo = string.Empty;
        public string ComboArchivo
        {
            get { return comboArchivo; }
            set { comboArchivo = value; OnPropertyChanged(); }
        }

        private string comboProveedor = string.Empty;
        public string ComboProveedor
        {
            get { return comboProveedor; }
            set { comboProveedor = value; OnPropertyChanged(); }
        }

        private string comboTipo = string.Empty;
        public string ComboTipo
        {
            get { return comboTipo; }
            set { comboTipo = value; OnPropertyChanged(); }
        }

        public event EventHandler<PropertyEventArgs> PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyEventArgs(propertyName));
        }
    }
}

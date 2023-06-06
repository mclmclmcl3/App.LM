using MiApp.LM.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.LM.Aplicacion.Wpf.Models
{
    public class ArbolElemento
    {
        public ObservableCollection<ArbolElemento> Elementos { get; set; }
        private Elemento elemento;
        public Elemento Elemento { get { return elemento; } set { elemento = value; } }
        public ArbolElemento(Elemento elemento)
        {
            Elementos = new ObservableCollection<ArbolElemento>();
            this.elemento = elemento;
        }
    }
}

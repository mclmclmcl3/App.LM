using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.LM.Dominio.Models
{
    public class Nodo
    {
        public Nodo(int nodoId, int izq, int dcha, int nivel)
        {
            NodoId = nodoId;
            Izq = izq;
            Dcha = dcha;
            Nivel = nivel;
        }

        public int NodoId { get; set; }
        public int Izq { get; set; }
        public int Dcha { get; set; }
        public int Nivel { get; set; }

        // Relacion uno a uno con Elemento
        public Elemento Elemento { get; set; }
    }
}

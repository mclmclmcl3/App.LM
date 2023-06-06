using MiApp.LM.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MiApp.LM.Aplicacion.Models
{
    public class InverseArbol
    {
        public List<Nodo> Nodos { get; }
        public InverseArbol(List<Nodo> nodos)
        {
            Nodos = nodos;
        }

        public void CrearAnidado()
        {
            foreach (var nodo in Nodos)
            {
                if (nodo.Izq == 1) // primer nodo
                {
                    nodo.Dato = "1";
                    nodo.Nivel = 1;
                }
                else // siguientes nodos
                {
                    if (nodo.Izq - 1 == PadreCercano(nodo.Izq, nodo.Dcha).Izq) // primer hijo
                    {
                        var padreInmediato = PadreCercano(nodo.Izq, nodo.Dcha);
                        nodo.Dato = padreInmediato.Dato + ".1";
                        nodo.Nivel = padreInmediato.Nivel + 1;
                    }
                    else // ultimo hijo modificado
                    {
                        var hermanoMayor = MayorHermano(nodo.Izq);
                        nodo.Dato = DatoDeHermano(hermanoMayor.Dato); // aqui sustituir ultima valor
                        nodo.Nivel = hermanoMayor.Nivel;
                    }
                }
            }
        }

        private string DatoDeHermano(string hermano)
        {
            string padre = hermano.Substring(0, hermano.LastIndexOf("."));
            int entero = Int32.Parse(hermano.Substring(hermano.LastIndexOf(".") + 1)) + 1;
            return padre + "." + entero;
        }
        private Nodo MayorHermano(int izq)
        {
            return Nodos.Where(n => n.Dcha + 1 == izq).First();
        }

        private Nodo PadreCercano(int izq, int dcha)
        {
            return Nodos.Where(n => n.Izq < izq && n.Dcha > dcha).ToList().MinBy(n => n.Dcha);
        }


    }

}

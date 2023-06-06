using MiApp.LM.Aplicacion.Wpf.Models;
using MiApp.LM.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Controls.Map;

namespace MiApp.LM.Presentacion.Wpf.Helpper
{
    public static class ArbolTreeView
    {
        public static ObservableCollection<ArbolElemento> ConstruirArbol(ObservableCollection<ArbolElemento> Arbol, ObservableCollection<Elemento> Elementos)
        {

            Stack<ArbolElemento> padres = new Stack<ArbolElemento>();
            foreach (var elemento in Elementos.OrderBy(x => x.Nodo.Izq))
            {
                ArbolElemento AE = new ArbolElemento(elemento);
                // Si es el primero
                if (padres.Count == 0)
                {
                    padres.Push(AE);
                }
                else
                {
                    bool salir = true;
                    while (salir)
                        // Si es hermano saco el de padres
                        if (elemento.Nodo.Izq > padres.Peek().Elemento.Nodo.Dcha && padres.Count > 1)
                            padres.Pop();
                        else
                            salir = false;

                    // Si es hijo del ultimo que hay en la pila
                    if (padres.Peek().Elemento.Nodo.Izq < elemento.Nodo.Izq && padres.Peek().Elemento.Nodo.Dcha > elemento.Nodo.Dcha)
                    {
                        padres.Peek().Elementos.Add(AE);
                        if (elemento.Nodo.Izq + 1 < elemento.Nodo.Dcha)
                            padres.Push(AE);
                    }
                }
            }
            var limpiar = true;
            while (limpiar)
                // Si es hermano saco el de padres
                if (padres.Count > 1)
                    padres.Pop();
                else
                    limpiar = false;
            Arbol = padres.Pop().Elementos;
            return Arbol;
        }
    }
}

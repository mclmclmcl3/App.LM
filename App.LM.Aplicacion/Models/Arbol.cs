using MiApp.LM.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.LM.Aplicacion.Models
{
    public class Arbol
    {
        private List<Nodo> ListaNodos = new List<Nodo>();
        private List<Nodo> ListaNodosNoInsertados = new List<Nodo>();
        Nodo padre = null;

        public List<Nodo> GetAll()
        {
            for (int i = 0; i < ListaNodos.Count; i++)
            {
                ListaNodos[i].Dato = ListaNodos[i].Dato.Substring(2);
            }
            return ListaNodos;
        }

        #region metodos para crear Arbol
        public void Insertar(Nodo nodo)
        {
            nodo.Dato = string.Concat("0.", nodo.Dato);
            if (ListaNodos.Count() == 0)
            {
                nodo.Izq = 1;
                nodo.Dcha = 2;
                nodo.Nivel = 1;
                ListaNodos.Add(nodo);
            }
            else
            {
                // Ya hay padres
                padre = CadenaPadre(nodo.Dato);
                if (padre != null)
                {
                    //"Padre"
                    nodo.Izq = padre.Dcha;
                    nodo.Dcha = padre.Dcha + 1;
                    nodo.Nivel = padre.Nivel + 1;

                    ListaNodos = OrganiceByNew(nodo, ListaNodos);
                    ListaNodos.Add(nodo);
                }
                else
                {
                    var hermano = HermanoByElemento(ListaNodos, nodo);
                    if (hermano != null)
                    {
                        //"Hermano"
                        nodo.Izq = hermano.Dcha + 1;
                        nodo.Dcha = hermano.Dcha + 2;
                        nodo.Nivel = hermano.Nivel;
                        ListaNodos = OrganiceByNew(nodo, ListaNodos);
                        ListaNodos.Add(nodo);
                    }
                    else
                    {
                        Console.WriteLine($"Error en: {nodo.Dato}");
                        ListaNodosNoInsertados.Add(nodo);
                    }
                }
            }
        }
        private Nodo HermanoByElemento(List<Nodo> cadenas, Nodo nodo)
        {
            if (cadenas.Count() == 0) return null;

            var nodoList = nodo.Dato.Split(".");
            var ultimo = nodoList[nodoList.Length - 1].Count();

            List<Nodo> hermanos = new List<Nodo>();
            foreach (var item in cadenas)
            {
                if (item.Dato.Contains(nodo.Dato.Substring(0, nodo.Dato.Length - (ultimo + 1))) && item.Dato.Count() == nodo.Dato.Count())
                {
                    hermanos.Add(item);
                }
            }
            return hermanos.OrderBy(e => e.Izq).LastOrDefault();
        }
        private List<Nodo> OrganiceByNew(Nodo nuevo, List<Nodo> arbol)
        {
            foreach (var original in arbol.Where(x => x.Dcha >= nuevo.Izq).ToList())
            {
                if (original.Izq < nuevo.Izq)
                    original.Dcha += 2;
                else
                {
                    original.Dcha += 2;
                    original.Izq += 2;
                }
            };
            return arbol;
        }
        private long ConvertirToNumber(string texto, int maxLont)
        {
            int[] arreglo = new int[maxLont];

            string[] cadenaArreglo = texto.Split('.');
            for (int i = 0; i < cadenaArreglo.Length; i++)
            {
                arreglo[i] = Int32.Parse(cadenaArreglo[i]);
            }
            return Int64.Parse(string.Join(string.Empty, arreglo));
        }
        private Nodo CadenaPadre(string texto)
        {
            if (texto.Contains('.'))
            {
                Nodo posiblePadre = null;
                for (int i = 0; i < texto.Split('.').Length; i++)
                {
                    var cadenaPadre = texto.Substring(0, texto.LastIndexOf('.'));
                    posiblePadre = ListaNodos.Where(n => n.Dato == cadenaPadre).FirstOrDefault();
                    if (posiblePadre != null)
                        return posiblePadre;
                    else
                        posiblePadre = null;

                    texto = texto.Substring(0, texto.LastIndexOf('.'));
                }
                return posiblePadre;
            }
            else return null;
        }
        #endregion

        #region Metodos para mover
        public void MoverElementos(List<Nodo> Lista, Nodo elementToMove, Nodo destino)
        {
            List<Nodo> ProvisionalBorrados = new List<Nodo>();
            if (ListaNodos.Count == 0) ListaNodos = Lista;

            // Borro los elementos a mover y los copio en ProvisionalBorrados
            ProvisionalBorrados = SeleccionPadreConHijos(elementToMove);
            ListaNodos.RemoveAll(x => ProvisionalBorrados.Contains(x));

            // Reordeno los elementos restantes
            int maxDechoBorrados = ProvisionalBorrados.Aggregate((x, y) => x.Dcha > y.Dcha ? x : y).Dcha;
            foreach (Nodo nodo in ListaNodos.Where(x => x.Izq > maxDechoBorrados))
            {
                nodo.Izq -= ProvisionalBorrados.Count * 2;
                nodo.Dcha -= ProvisionalBorrados.Count * 2;
            }
            // hago hueco para los elementos a mover
            HacerHuecoParaMovidos(ProvisionalBorrados);

            // Reordeno los elementos borrados
            ProvisionalBorrados = ReiniciarNumeracion(ProvisionalBorrados);
            foreach (var item in ProvisionalBorrados)
            {
                item.Izq += destino.Dcha;
                item.Dcha += destino.Dcha;
            }
            // Uno las listas.
            ListaNodos.AddRange(ProvisionalBorrados);

            CrearDato(ListaNodos);
        }
        public List<Nodo> ReiniciarNumeracion(List<Nodo> Lista)
        {
            int cant = Lista.Aggregate((x, y) => x.Izq < y.Izq ? x : y).Izq - 1;
            foreach (Nodo nodo in Lista)
            {
                nodo.Izq -= cant;
                nodo.Dcha -= cant;
            }
            return Lista;
        }
        private List<Nodo> SeleccionPadreConHijos(Nodo padre)
        {
            return ListaNodos.Where(ln => ln.Izq >= padre.Izq && ln.Dcha <= padre.Dcha).ToList();
        }
        private void HacerHuecoParaMovidos(List<Nodo> elementosMovidos)
        {
            int cantidad = elementosMovidos.Count * 2;

            var elementosMoverCantidad = from item in ListaNodos
                                         where item.Izq > elementosMovidos.Max(m => m.Dcha)
                                         select item;

            var elementosMoverSoloDcha = from item in ListaNodos
                                         where item.Izq < elementosMovidos.Min(m => m.Izq) && item.Dcha > elementosMovidos.Max(m => m.Dcha)
                                         select item;

            foreach (var item in elementosMoverCantidad.ToList())
            {
                item.Izq = item.Izq + cantidad;
                item.Dcha = item.Dcha + cantidad;
            }
            foreach (var item in elementosMoverSoloDcha.ToList())
            {
                item.Dcha = item.Dcha + cantidad;
            }

        }
        private void InsertarElementos(List<Nodo> elementosMovidos, Nodo destino)
        {
            var restaurar = elementosMovidos.Min(m => m.Izq);
            foreach (var item in elementosMovidos)
            {
                // ponogo la numeracion a 1
                item.Izq = item.Izq - restaurar + 1;
                item.Dcha = item.Dcha - restaurar + 1;

                // incremento la numeracion al destino
                item.Izq = item.Izq + destino.Dcha;
                item.Dcha = item.Dcha + destino.Dcha;
            }
        }

        #endregion

        #region Convertir arbol izq-dcha a lista anidada
        public static void CrearDato(List<Nodo> nodos)
        {
            foreach (var nodo in nodos.OrderBy(x => x.Izq))
            {
                if (nodo.Izq == 1)
                {
                    nodo.Dato = "1";
                    nodo.Nivel = 1;
                }
                else
                {
                    var padreInmediato = PadreCercano(nodos, nodo.Izq, nodo.Dcha);
                    if (nodo.Izq - 1 == padreInmediato.Izq) // primer hijo
                    {
                        nodo.Dato = padreInmediato.Dato + ".1";
                        nodo.Nivel = padreInmediato.Nivel + 1;
                    }
                    else // ultimo hijo modificado
                    {
                        var hermanoMayor = MayorHermano(nodos, nodo.Izq, nodo.Dcha);
                        nodo.Dato = DatoDeHermano(hermanoMayor.Dato); // aqui sustituir ultima valor
                        nodo.Nivel = hermanoMayor.Nivel;
                    }
                }
            }
        }
        public static string DatoDeHermano(string hermano)
        {
            string padre = hermano.Substring(0, hermano.LastIndexOf("."));
            int entero = Int32.Parse(hermano.Substring(hermano.LastIndexOf(".") + 1)) + 1;
            return padre + "." + entero;
        }
        public static Nodo MayorHermano(List<Nodo> nodos, int izq, int dcha)
        {
            return nodos.Where(n => n.Dcha + 1 == izq).First();
        }
        public static Nodo PadreCercano(List<Nodo> nodos, int izq, int dcha)
        {
            return nodos.Where(n => n.Izq < izq && n.Dcha > dcha).ToList().MinBy(n => n.Dcha);
        }
        #endregion


    }
}

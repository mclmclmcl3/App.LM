using MiApp.LM.Dominio.Models;
using System.Collections.Generic;
using System.Linq;

namespace MiApp.LM.Presentacion.Wpf.Controller
{
    public class ElementoController : IElementoController
    {
        private List<Elemento> _listaElementos;

        public ElementoController()
        {
            _listaElementos = new List<Elemento>()
            {
                new Elemento()
                {
                    ElementoId = 1,
                    ProyectoId = 1,
                    Nombre ="P001-H00",
                    Descripcion ="Horno",
                    Conjunto = "Horno",
                    SubConjunto ="",
                    Comentario = "Metido en Navision",
                    Estado = "Ofertando",
                    ColoBg = "LightBlue",
                    Fabricante ="Molecor",
                    Proveedor ="",
                    Precio = 300000.00,
                    Nodo = new Nodo(1, 1, 10, 0)
                },
                new Elemento()
                {
                    ElementoId = 2,
                    ProyectoId = 1,
                    Nombre ="P001-H00.1",
                    Descripcion ="Horno",
                    Conjunto = "Horno",
                    SubConjunto ="Estructura",
                    Comentario = "",
                    Estado = "Pedido",
                    ColoBg = "LightBlue",
                    Fabricante ="Molecor",
                    Proveedor ="",
                    Precio = 86200.00,
                    Nodo = new Nodo(2, 2, 5, 1)
                },
                new Elemento()
                {
                    ElementoId = 3,
                    ProyectoId = 1,
                    Nombre ="P001-H00.1-001",
                    Descripcion ="Horno",
                    Conjunto = "Horno",
                    SubConjunto ="Estructura",
                    Comentario = "",
                    Estado = "Recibido",
                    ColoBg = "yellow",
                    Fabricante ="Molecor",
                    Proveedor ="",
                    Precio = 86200.00,
                    Nodo = new Nodo(3, 3, 4, 2)
                },
                new Elemento()
                {
                    ElementoId = 4,
                    ProyectoId = 1,
                    Nombre ="P001-H00.2",
                    Descripcion ="Horno",
                    Conjunto = "Horno",
                    SubConjunto ="Estructura",
                    Comentario = "",
                    Estado = "Recibido",
                    ColoBg = "#FFFFA280",
                    Fabricante ="Molecor",
                    Proveedor ="",
                    Precio = 600.25,
                    Nodo = new Nodo(4, 6, 9, 1)
                },
                new Elemento()
                {
                    ElementoId = 5,
                    ProyectoId = 1,
                    Nombre ="P001-H00.2-001",
                    Descripcion ="Horno",
                    Conjunto = "Horno",
                    SubConjunto ="Estructura",
                    Comentario = "",
                    Estado = "Recibido",
                    ColoBg = "#FFFFA280",
                    Fabricante ="Molecor",
                    Proveedor ="",
                    Precio = 600.25,
                    Nodo = new Nodo(5, 7, 8, 2)
                },
                new Elemento()
                {
                    ElementoId = 6,
                    ProyectoId = 2,
                    Nombre ="P002-H00",
                    Descripcion ="Horno",
                    Conjunto = "Horno",
                    SubConjunto ="Estructura",
                    Comentario = "",
                    Estado = "Recibido",
                    ColoBg = "transparent",
                    Fabricante ="Molecor",
                    Proveedor ="",
                    Precio = 600.25,
                    Nodo = new Nodo(6, 1, 4, 0)
                },
                new Elemento()
                {
                    ElementoId = 7,
                    ProyectoId = 2,
                    Nombre ="P002-H00.1",
                    Descripcion ="Oruga",
                    Conjunto = "Horno",
                    SubConjunto ="Estructura",
                    Comentario = "",
                    Estado = "Recibido",
                    ColoBg = "transparent",
                    Fabricante ="Molecor",
                    Proveedor ="",
                    Precio = 600.25,
                    Nodo = new Nodo(7, 2, 3, 1)
                },
                new Elemento()
                {
                    ElementoId = 8,
                    ProyectoId = 3,
                    Nombre ="P003-H00",
                    Descripcion ="Horno",
                    Conjunto = "Horno",
                    SubConjunto ="Estructura",
                    Comentario = "",
                    Estado = "Recibido",
                    ColoBg = "transparent",
                    Fabricante ="Molecor",
                    Proveedor ="",
                    Precio = 600.25,
                    Nodo = new Nodo(8, 1, 2, 0)
                },
                new Elemento()
                {
                    ElementoId = 9,
                    ProyectoId = 4,
                    Nombre ="ID01-HACC",
                    Descripcion ="Horno",
                    Conjunto = "Horno",
                    SubConjunto ="Estructura",
                    Comentario = "",
                    Estado = "Recibido",
                    ColoBg = "transparent",
                    Fabricante ="Molecor",
                    Proveedor ="",
                    Precio = 600.25,
                    Nodo = new Nodo(9, 1, 2, 0)
                },
            };
        }

        public List<Elemento> GetAll() => _listaElementos;
        public List<Elemento> GetAllByProyecto(int proyectoId)
        {
            if (proyectoId == -1) return _listaElementos;

            var listado = _listaElementos.Where(x => x.ProyectoId == proyectoId).ToList();
            return listado;
        }

        public void Insertar(Elemento elemento)
        {
            _listaElementos.Add(elemento);
        }

        public Elemento GetById(int id)
        {
            return _listaElementos.FirstOrDefault(p => p.ElementoId == id)!;
        }
    }

}

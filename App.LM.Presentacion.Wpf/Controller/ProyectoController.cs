using MiApp.LM.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows;

namespace MiApp.LM.Presentacion.Wpf.Controller
{
    public class ProyectoController : IProyectoController
    {
        private List<Proyecto> _listaProyectos;

        public ProyectoController()
        {
            _listaProyectos = new List<Proyecto>()
            {
                new Proyecto() {ProyectoId=1, Nombre ="P001", Descripcion ="Loeches 01"},
                new Proyecto() {ProyectoId=2, Nombre ="P002", Descripcion ="Loeches 02"},
                new Proyecto() {ProyectoId=3, Nombre ="P003", Descripcion ="Loeches 03"},
                new Proyecto() {ProyectoId=4, Nombre ="ID01", Descripcion ="ACC L1"},
                new Proyecto() {ProyectoId=5, Nombre ="ID02", Descripcion ="ACC L2"},
                new Proyecto() {ProyectoId=6, Nombre ="ID03", Descripcion ="Corte Tubo Corrugado"}
            };
        }

        public List<Proyecto> GetAll() => _listaProyectos;

        public void Insertar(Proyecto proyecto)
        {
            proyecto.ProyectoId = _listaProyectos.Count + 1;
            _listaProyectos.Add(proyecto);
        }

        public Proyecto GetById(int id)
        {
            return _listaProyectos.FirstOrDefault(p => p.ProyectoId == id);
        }

        public List<Proyecto> FiltroContiene(string filtro)
        {
            return _listaProyectos.Where(x => x.Nombre.Contains(filtro)).ToList();
        }

        public List<Proyecto> FiltroEmpiezaPor(string filtro)
        {
            return _listaProyectos.Where(x => x.Nombre.StartsWith(filtro)).ToList();
        }

        public List<Proyecto> Filtro(Expression<Func<Proyecto, bool>> proyExpresion)
        {
            var listado = _listaProyectos.AsQueryable();
            return listado.Where(proyExpresion).Select(p => p).ToList();
        }

        public bool Existe(string nombre)
        {
            return _listaProyectos.Any(x => x.Nombre == nombre);
        }

        public void Remove(Proyecto proyecto)
        {
            _listaProyectos.Remove(proyecto);
        }

        public void Actualizar(Proyecto proyecto)
        {
            var item = _listaProyectos.FirstOrDefault(x => x.ProyectoId == proyecto.ProyectoId);

            if (item != null)
            {
                MessageBox.Show($"Bd: {item.ProyectoId}, A Modificar: {proyecto.ProyectoId}");
                item.Nombre = proyecto.Nombre;
                item.Descripcion = proyecto.Descripcion;
            }
        }

    }
}

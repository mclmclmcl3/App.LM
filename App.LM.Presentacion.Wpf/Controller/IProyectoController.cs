using MiApp.LM.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MiApp.LM.Presentacion.Wpf.Controller
{
    public interface IProyectoController
    {
        void Actualizar(Proyecto proyecto);
        bool Existe(string nombre);
        List<Proyecto> Filtro(Expression<Func<Proyecto, bool>> proyExpresion);
        List<Proyecto> FiltroContiene(string filtro);
        List<Proyecto> FiltroEmpiezaPor(string filtro);
        List<Proyecto> GetAll();
        Proyecto GetById(int id);
        void Insertar(Proyecto proyecto);
        void Remove(Proyecto proyecto);
    }
}
using MiApp.LM.Dominio.Models;
using System.Collections.Generic;

namespace MiApp.LM.Presentacion.Wpf.Controller
{
    public interface IElementoController
    {
        List<Elemento> GetAll();
        List<Elemento> GetAllByProyecto(int proyectoId);
        Elemento GetById(int id);
        void Insertar(Elemento elemento);
    }
}
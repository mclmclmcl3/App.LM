using MiApp.LM.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.LM.Dominio.Abstracciones
{
    public interface IProyectosRepository
    {
        Task<Proyecto> GetById(int id);
        Task<List<Proyecto>> GetAllProyectos();
        Task Insert(Proyecto proyecto);
        Task Update(Proyecto proyecto);
        Task Delete(int id);
        Task<bool> DeleteAll();
        Task<Proyecto> GetByNombre(string nombre);
        Task<bool> Existe(int id);
        Task<bool> Existe(string nombre);
    }
}

using MiApp.LM.Dominio.Abstracciones;
using MiApp.LM.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.LM.Infactustura.Repositories
{
    public class ProyectosRepository : IProyectosRepository
    {
        public async Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAll()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Existe(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Existe(string nombre)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Proyecto>> GetAllProyectos()
        {
            throw new NotImplementedException();
        }

        public async Task<Proyecto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Proyecto> GetByNombre(string nombre)
        {
            throw new NotImplementedException();
        }

        public async Task Insert(Proyecto proyecto)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Proyecto proyecto)
        {
            throw new NotImplementedException();
        }
    }
}

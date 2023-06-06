using MiApp.LM.Dominio.Abstracciones;
using MiApp.LM.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.LM.Infactustura.Repositories
{
    public class ElementosRepository : IElementosRepository
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

        public async Task<List<Elemento>> GetAllElementos()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Elemento>> GetAllElementosById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Elemento> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Insert(Elemento elemento)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Elemento elemento)
        {
            throw new NotImplementedException();
        }
    }
}

using MiApp.LM.Dominio.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiApp.LM.Dominio.Abstracciones
{
    public interface IElementosRepository
    {
        Task<Elemento> GetById(int id);
        Task<List<Elemento>> GetAllElementos();
        Task<List<Elemento>> GetAllElementosById(int id);
        Task Insert(Elemento elemento);
        Task Update(Elemento elemento);
        Task Delete(int id);
        Task<bool> DeleteAll();
        Task<bool> Existe(int id);
        Task<bool> Existe(string nombre);
    }
}

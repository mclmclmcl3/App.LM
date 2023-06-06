using MiApp.LM.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.LM.Dominio.Abstracciones
{
    public interface IInventorRepository
    {
        Task<List<InventorExcel>> GetAll();
        Task<List<string>> NombresColumnas();
    }
}

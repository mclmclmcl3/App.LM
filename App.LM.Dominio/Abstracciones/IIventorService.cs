using MiApp.LM.Dominio.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiApp.LM.Aplicacion.Services.Inventor
{
    public interface IIventorService
    {
        Task<List<string>> CargarColumnasExcelInventor(string ruta);
        Task<List<string>> CargarColumnasTeoricas();
        Task<List<InventorExcel>> GetAllData(string ruta);
        Task<bool> VerificarColumnas(string ruta);
    }
}

using MiApp.LM.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.LM.Dominio.Abstracciones
{
    public interface IInventorRepository2
    {
        void CargarArchivo(string filePath);
        Task<List<InventorExcel>> GetAll();
        Task<List<string>> GetColumEndWith(string nombreColumna, string terminacion);
        Task<List<string>> GetColumnUniques(string nombreColumna);
        Task<List<InventorExcel>> GetRodamientos();
        Task<InventorExcel> GetRowObject(int row);
        Task<List<InventorExcel>> GetTornilleria();
        Task<List<InventorExcel>> GetVigas();
        Task<List<string>> NombresColumnas();
    }
}

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
        List<InventorExcel> DataExcel { get; set; }
        //List<string> ColumnasExcel { get; set; }

        Task<List<string>> EncabezadosExcel(string filePath);
        Task LeerDatos(string filePath);
    }
}

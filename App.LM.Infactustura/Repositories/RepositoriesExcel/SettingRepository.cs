using MiApp.LM.Dominio.Abstracciones;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.LM.Infactustura.Repositories.RepositoriesExcel
{
    public class SettingRepository : ISettingRepository
    {
        private string filePath = "/Resources/Setting/SettingApp.xlsx";
        private FileInfo archivo = null;
        private ExcelWorksheet hoja;

        public SettingRepository()
        {
            
        }
    }
}

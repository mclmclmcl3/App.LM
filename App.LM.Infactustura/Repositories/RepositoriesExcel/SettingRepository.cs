using MiApp.LM.Dominio.Abstracciones;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.LM.Infactustura.Repositories.RepositoriesExcel
{
    public class SettingRepository : ISettingRepository
    {
        //private string filePath = @"../Resources/Setting/SettingApp.xlsx";
        private string filePath = @"Resources\Setting\SettingApp.xlsx";
        private FileInfo archivo = null;
        private ExcelWorksheet setting;
        private ExcelWorksheet rutas;
        private ExcelWorksheet tornilleria;

        public SettingRepository()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        public async Task<List<string>> GetAllColumnasInventor()
        {
            return await Task.Run(() =>
            {
                List<string> temporal = new List<string>();
                using (ExcelPackage libro = new ExcelPackage(new FileInfo(filePath)))
                {
                    setting = libro.Workbook.Worksheets["Setting"];
                    if (setting != null)
                    {
                        for (int i = 2; i <= setting.Dimension.Rows; i++)
                        {
                            temporal.Add(setting.Cells[i, 1].Value.ToString());
                        }
                    }
                }
                return temporal;
            });
        }
        public async Task UpdateColumnasInventor(List<string> datosNuevos)
        {
            if(!datosNuevos.Contains(string.Empty))
            {
                await DelAllColumnasInventor();
                await Task.Run(() =>
                {
                    using (ExcelPackage libro = new ExcelPackage(new FileInfo(filePath)))
                    {
                        setting = libro.Workbook.Worksheets["Setting"];
                        if (setting != null)
                        {
                            for (int i = 0; i < datosNuevos.Count; i++)
                            {
                                setting.Cells[i + 2, 1].Value = datosNuevos[i];
                            }
                        }
                        libro.Save();
                    }
                });
            }
        }
        public async Task DelAllColumnasInventor()
        {
            await Task.Run(() =>
            {
                List<string> temporal = new List<string>();
                using (ExcelPackage libro = new ExcelPackage(new FileInfo(filePath)))
                {
                    setting = libro.Workbook.Worksheets["Setting"];
                    if (setting != null)
                    {
                        for (int i = 2; i <= setting.Dimension.Rows; i++)
                        {
                            setting.Cells[i, 1].Value = "";
                        }
                    }
                    libro.Save();
                }
            });
        }

        public async Task BorrarRutaMaestro()
        {
            await Task.Run(() =>
            {
                List<string> temporal = new List<string>();
                using (ExcelPackage libro = new ExcelPackage(new FileInfo(filePath)))
                {
                    rutas = libro.Workbook.Worksheets["Rutas"];
                    if (setting != null)
                    {
                        rutas.Cells[3, 2].Value = "";
                    }
                    libro.Save();
                }
            });
        }
        public async Task UpdatetRutaMaestro(string rutaNuevaMaestro)
        {
            if (!rutaNuevaMaestro.Equals(string.IsNullOrEmpty))
            {
                await Task.Run(() =>
                {
                    using (ExcelPackage libro = new ExcelPackage(new FileInfo(filePath)))
                    {
                        rutas = libro.Workbook.Worksheets["Rutas"];
                        if (setting != null)
                        {
                            setting.Cells[3, 2].Value = rutaNuevaMaestro;
                        }
                        libro.Save();
                    }
                });
            }
        }
        public async Task<string> GetRutaMaestro() => await Task.Run(() =>
                                                               {
                                                                   string temporal = "";
                                                                   using (ExcelPackage libro = new ExcelPackage(new FileInfo(filePath)))
                                                                   {
                                                                       rutas = libro.Workbook.Worksheets["Rutas"];
                                                                       if (setting != null)
                                                                       {
                                                                           setting.Cells[3, 2].Value.ToString();
                                                                       }
                                                                   }
                                                                   return temporal;
                                                               });
    }
}

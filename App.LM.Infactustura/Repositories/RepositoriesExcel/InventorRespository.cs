using MiApp.LM.Dominio.Abstracciones;
using MiApp.LM.Dominio.Models;
using Microsoft.Extensions.Configuration;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.LM.Infactustura.Repositories.RepositoriesExcel
{

    public class InventorRepository : IInventorRepository
    {
        private FileInfo archivo = null;
        private ExcelWorksheet hoja;

        public List<InventorExcel> DataExcel { get; set; }

        public InventorRepository()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            DataExcel = new List<InventorExcel>();
            //ColumnasExcel = new List<string>();
            using (ExcelPackage libro = new ExcelPackage(archivo))
            {
                hoja = libro.Workbook.Worksheets["BOM"];
            }
        }

        public async Task<List<string>> EncabezadosExcel(string filePath)
        {
            return await Task.Run(() =>
            {
                List<string> encabezados = new List<string>();
                if (Ok(filePath))
                {
                    using (ExcelPackage libro = new ExcelPackage(archivo))
                    {
                        hoja = libro.Workbook.Worksheets["BOM"];
                        if (hoja != null)
                        {
                            int totalCol = hoja.Dimension.Columns;
                            for (int i = 1; i < totalCol; i++)
                            {
                                encabezados.Add(hoja.Cells[1, i].Value?.ToString());
                            }
                        }
                    }
                }
                return encabezados;
            });
        }

        public async Task LeerDatos(string filePath)
        {
            await Task.Run(() =>
            {
                if (Ok(filePath))
                {
                    using (ExcelPackage libro = new ExcelPackage(archivo))
                    {
                        hoja = libro.Workbook.Worksheets["BOM"];
                        if (hoja != null)
                        {
                            int totalRows = hoja.Dimension.Rows;
                            var UbicacionEncabezados = PosicionesEncabezadosExcel();

                            for (int row = 2; row <= totalRows; row++)
                            {
                                InventorExcel inventario = new InventorExcel();

                                if (UbicacionEncabezados.ContainsKey("Elemento"))
                                    inventario.Elemento = hoja.Cells[row, UbicacionEncabezados["Elemento"]].Value?.ToString();
                                if (UbicacionEncabezados.ContainsKey("CTDAD"))
                                    inventario.Cantidad = hoja.Cells[row, UbicacionEncabezados["CTDAD"]].Value?.ToString();
                                if (UbicacionEncabezados.ContainsKey("Nº de pieza"))
                                    inventario.Nombre = hoja.Cells[row, UbicacionEncabezados["Nº de pieza"]].Value?.ToString();
                                if (UbicacionEncabezados.ContainsKey("Descripción"))
                                    inventario.Descripcion = hoja.Cells[row, UbicacionEncabezados["Descripción"]].Value?.ToString();
                                if (UbicacionEncabezados.ContainsKey("CTDAD de unidades"))
                                    inventario.Material = hoja.Cells[row, UbicacionEncabezados["Material"]].Value?.ToString();
                                if (UbicacionEncabezados.ContainsKey("Material"))
                                    inventario.CantidadElementos = hoja.Cells[row, UbicacionEncabezados["CTDAD de elementos"]].Value?.ToString();
                                if (UbicacionEncabezados.ContainsKey("CTDAD de elementos"))
                                    inventario.CantidadUnidades = hoja.Cells[row, UbicacionEncabezados["CTDAD de unidades"]].Value?.ToString();
                                if (UbicacionEncabezados.ContainsKey("Masa"))
                                    inventario.Masa = hoja.Cells[row, UbicacionEncabezados["Masa"]].Value?.ToString();
                                if (UbicacionEncabezados.ContainsKey("Nombre de archivo"))
                                    inventario.Archivo = hoja.Cells[row, UbicacionEncabezados["Nombre de archivo"]].Value?.ToString();
                                if (UbicacionEncabezados.ContainsKey("Proveedor"))
                                    inventario.Proveedor = hoja.Cells[row, UbicacionEncabezados["Proveedor"]].Value?.ToString();
                                if (UbicacionEncabezados.ContainsKey("Tipo de componente"))
                                    inventario.Tipo = hoja.Cells[row, UbicacionEncabezados["Tipo de componente"]].Value?.ToString();

                                DataExcel.Add(inventario);
                            }
                        }
                    }
                }
                else
                {
                    archivo = null;
                }
            });
        }

        private Dictionary<string, int> PosicionesEncabezadosExcel()
        {
            Dictionary<string, int> Posiciones = new Dictionary<string, int>();
            for (int col = 1; col <= this.hoja.Dimension.Columns; col++)
            {
                Posiciones.Add(this.hoja.Cells[1, col].Value?.ToString(), col);
            }
            //ColumnasExcel = Posiciones.Keys.ToList();
            return Posiciones;
        }
        private bool Ok(string filePath)
        {
            archivo = new FileInfo(filePath);
            return archivo.Exists;
        }
    }
}

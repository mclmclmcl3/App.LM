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
    public interface IInventorRepository
    {
        List<InventorExcel> DataExcel { get; set; }
        List<string> ColumnasExcel { get; set; }

        void LeerDatos(string filePath);
    }
    public class InventorRepository : IInventorRepository
    {
        private string filePath = @"C:\Users\myb19\Desktop\ID011 LM Horno Estructurado.xlsx";
        private FileInfo archivo = null;
        private ExcelWorksheet hoja;
        public List<string> ColumnasExcel { get; set; }
        public List<InventorExcel> DataExcel { get; set; }

        public InventorRepository()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            DataExcel = new List<InventorExcel>();
            ColumnasExcel = new List<string>();
            using (ExcelPackage libro = new ExcelPackage(archivo))
            {
                hoja = libro.Workbook.Worksheets["BOM"];
            }
        }

        public void LeerDatos(string filePath)
        {   
            if(Ok(filePath))
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
                                inventario.CantidadUnidades = hoja.Cells[row, UbicacionEncabezados["CTDAD de unidades"]].Value?.ToString();
                            if (UbicacionEncabezados.ContainsKey("Masa"))
                                inventario.Masa = hoja.Cells[row, UbicacionEncabezados["Masa"]].Value?.ToString();
                            if (UbicacionEncabezados.ContainsKey("Nombre de archivo"))
                                inventario.Archivo = hoja.Cells[row, UbicacionEncabezados["Nombre de archivo"]].Value?.ToString();
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
                filePath = string.Empty;
            }
        }

        private Dictionary<string, int> PosicionesEncabezadosExcel()
        {
            Dictionary<string, int> Posiciones = new Dictionary<string, int>();
            for (int col = 1; col <= this.hoja.Dimension.Columns; col++)
            {
                Posiciones.Add(this.hoja.Cells[1, col].Value?.ToString(), col);
            }
            ColumnasExcel = Posiciones.Keys.ToList();
            return Posiciones;
        }
        private bool Ok(string filePath)
        {
            archivo = new FileInfo(filePath);
            return archivo.Exists;
        }

    }
}

using MiApp.LM.Dominio.Abstracciones;
using MiApp.LM.Dominio.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.LM.Infactustura.Repositories.RepositoriesExcel
{
    // https://github.com/EPPlusSoftware/EPPlus/wiki/ToCollection
    public class InventorRepository2 : IInventorRepository2
    {
        private string filePath = @"C:\Users\myb19\Desktop\ID011 LM Horno Estructurado.xlsx";
        private FileInfo archivo = null;
        private List<string> columnasNames = new List<string>() { "Elemento", "CTDAD", "Nº de pieza", "Descripción", "CTDAD de unidades", "Masa", "Nombre de archivo", "Tipo de componente" };
        
        public InventorRepository2()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }
        public void CargarArchivo(string filePath)
        {
            this.filePath = filePath;
            archivo = new FileInfo(this.filePath);
        }

        public async Task<List<string>> NombresColumnas()
        {
            if (archivo == null) return null;
            List<string> nombres = new List<string>();
            await Task.Run(() =>
            {
                using ExcelPackage libro = new ExcelPackage(archivo);
                ExcelWorksheet hoja = libro.Workbook.Worksheets[0];
                int columnCount = hoja.Dimension.Columns;

                for (int col = 1; col <= columnCount; col++)
                {
                    nombres.Add(hoja.Cells[1, col].Value?.ToString());
                }
            });
            return nombres;
        }
        public async Task<List<string>> GetColumnUniques(string nombreColumna)
        {
            if (archivo == null) return null;
            HashSet<string> nombres = new HashSet<string>();
            await Task.Run(() =>
            {
                using ExcelPackage libro = new ExcelPackage(archivo);
                ExcelWorksheet hoja = libro.Workbook.Worksheets[0];
                int cantFilas = hoja.Dimension.Rows;
                int numCol = GetColumnIndexByName(hoja, nombreColumna);

                for (int i = 2; i <= cantFilas; i++)
                {
                    nombres.Add(hoja.Cells[i, numCol].Value?.ToString());
                }
            });
            return nombres.ToList();
        }
        public async Task<List<InventorExcel>> GetAll()
        {
            if (archivo == null) return null;

            List<InventorExcel> datos = new List<InventorExcel>();
            try
            {
                await Task.Run(() =>
                {
                    using ExcelPackage libro = new ExcelPackage(archivo);
                    ExcelWorksheet hoja = libro.Workbook.Worksheets[0];

                    int colCount = hoja.Dimension.End.Column;
                    int rowCount = hoja.Dimension.End.Row;

                    for (int row = 2; row <= rowCount; row++)
                    {
                        InventorExcel tabla = new InventorExcel();

                        int Elemento = GetColumnIndexByName(hoja, "Elemento");
                        tabla.Elemento = (hoja.Cells[row, Elemento].Value == null) ? "" : hoja.Cells[row, Elemento].Value.ToString();

                        int CTDAD = GetColumnIndexByName(hoja, "CTDAD");
                        tabla.Cantidad = (hoja.Cells[row, CTDAD].Value == null) ? "" : hoja.Cells[row, CTDAD].Value.ToString();

                        int pieza = GetColumnIndexByName(hoja, "Nº de pieza");
                        tabla.Nombre = (hoja.Cells[row, pieza].Value == null) ? "" : hoja.Cells[row, pieza].Value.ToString();

                        int descripcion = GetColumnIndexByName(hoja, "Descripción");
                        tabla.Descripcion = (hoja.Cells[row, descripcion].Value == null) ? "" : hoja.Cells[row, descripcion].Value.ToString();

                        int CTDADund = GetColumnIndexByName(hoja, "CTDAD de unidades");
                        tabla.CantidadUnidades = (hoja.Cells[row, CTDADund].Value == null) ? "" : hoja.Cells[row, CTDADund].Value.ToString();

                        int Masa = GetColumnIndexByName(hoja, "Masa");
                        tabla.Masa = (hoja.Cells[row, Masa].Value == null) ? "" : hoja.Cells[row, Masa].Value.ToString();

                        int Narchivo = GetColumnIndexByName(hoja, "Nombre de archivo");
                        tabla.Archivo = (hoja.Cells[row, Narchivo].Value == null) ? "" : hoja.Cells[row, Narchivo].Value.ToString();

                        int tipoComponente = GetColumnIndexByName(hoja, "Tipo de componente");
                        tabla.Tipo = (hoja.Cells[row, tipoComponente].Value == null) ? "" : hoja.Cells[row, tipoComponente].Value.ToString();

                        datos.Add(tabla);
                    }
                });
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync("Error");
            }
 
            return datos;
        }
        public async Task<List<string>> GetColumEndWith(string nombreColumna, string terminacion)
        {
            if (archivo == null) return null;
            List<string> nombres = new List<string>();
            await Task.Run(() =>
            {
                using ExcelPackage libro = new ExcelPackage(archivo);
                ExcelWorksheet hoja = libro.Workbook.Worksheets[0];
                int cantFilas = hoja.Dimension.Rows;
                int numCol = GetColumnIndexByName(hoja, nombreColumna);

                for (int i = 2; i <= cantFilas; i++)
                {
                    nombres.Add(hoja.Cells[i, numCol].Value.ToString());
                }
            });
            return nombres.Where(n => n.EndsWith(terminacion)).ToList();
        }
        public async Task<InventorExcel> GetRowObject(int row)
        {
            if (archivo == null) return null;
            InventorExcel inventor = new InventorExcel();
            await Task.Run(() =>
            {
                using ExcelPackage libro = new ExcelPackage(archivo);
                ExcelWorksheet hoja = libro.Workbook.Worksheets[0];
                int cantFilas = hoja.Dimension.Rows;
                if (row <= cantFilas)
                {
                    int Elemento = GetColumnIndexByName(hoja, "Elemento");
                    inventor.Elemento = (hoja.Cells[row, Elemento].Value == null) ? "" : hoja.Cells[row, Elemento].Value.ToString();

                    int CTDAD = GetColumnIndexByName(hoja, "CTDAD");
                    inventor.Cantidad = (hoja.Cells[row, CTDAD].Value == null) ? "" : hoja.Cells[row, CTDAD].Value.ToString();

                    int pieza = GetColumnIndexByName(hoja, "Nº de pieza");
                    inventor.Nombre = (hoja.Cells[row, pieza].Value == null) ? "" : hoja.Cells[row, pieza].Value.ToString();

                    int descripcion = GetColumnIndexByName(hoja, "Descripción");
                    inventor.Descripcion = (hoja.Cells[row, descripcion].Value == null) ? "" : hoja.Cells[row, descripcion].Value.ToString();

                    int CTDADund = GetColumnIndexByName(hoja, "CTDAD de unidades");
                    inventor.CantidadUnidades = (hoja.Cells[row, CTDADund].Value == null) ? "" : hoja.Cells[row, CTDADund].Value.ToString();

                    int Masa = GetColumnIndexByName(hoja, "Masa");
                    inventor.Masa = (hoja.Cells[row, Masa].Value == null) ? "" : hoja.Cells[row, Masa].Value.ToString();

                    int Narchivo = GetColumnIndexByName(hoja, "Nombre de archivo");
                    inventor.Archivo = (hoja.Cells[row, Narchivo].Value == null) ? "" : hoja.Cells[row, Narchivo].Value.ToString();

                    int tipoComponente = GetColumnIndexByName(hoja, "Tipo de componente");
                    inventor.Tipo = (hoja.Cells[row, tipoComponente].Value == null) ? "" : hoja.Cells[row, tipoComponente].Value.ToString();
                }
            });
            return inventor;
        }
        public async Task<List<InventorExcel>> GetVigas()
        {
            if (archivo == null) return null;
            var lista = await GetAll();
            return lista.Where(i => i.CantidadUnidades.ToString().EndsWith("mm")).ToList();
        }
        public async Task<List<InventorExcel>> GetTornilleria()
        {
            if (archivo == null) return null;
            var lista = await GetAll();
            return lista.Where(i => i.Nombre.ToString().StartsWith("DIN") && !i.Descripcion.StartsWith("Rodamiento")).ToList();
        }
        public async Task<List<InventorExcel>> GetRodamientos()
        {
            if (archivo == null) return null;
            var lista = await GetAll();
            return lista.Where(i => i.Descripcion.StartsWith("Rodamiento")).ToList();
        }

        private Object? Celda(int row, string columna, ExcelWorksheet hoja)
        {
            int tipoComponente = GetColumnIndexByName(hoja, columna);
            return (hoja.Cells[row, tipoComponente].Value == null) ? null : hoja.Cells[row, tipoComponente].Value;
        }
        private int GetColumnIndexByName(ExcelWorksheet worksheet, string columnName)
        {
            int columnCount = worksheet.Dimension.Columns;

            for (int col = 1; col <= columnCount; col++)
            {
                string headerValue = worksheet.Cells[1, col].Value?.ToString();
                if (headerValue == columnName)
                {
                    return col;
                }
            }

            return -1; // Columna no encontrada
        }


    }

}

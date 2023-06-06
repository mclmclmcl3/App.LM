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
    public class InventorRepository : IInventorRepository
    {
        private string filePath = @"C:\Users\myb19\Desktop\ID011 LM Horno Estructurado.xlsx";
        private FileInfo archivo;
        private List<string> columnasNames = new List<string>() { "Elemento", "CTDAD", "Nº de pieza", "Descripción", "CTDAD de unidades", "Masa", "Nombre de archivo", "Tipo de componente" };

        public InventorRepository()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            archivo = new FileInfo(filePath);
        }

        public async Task<List<string>> NombresColumnas()
        {
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
        public async Task<List<InventorExcel>> GetAll()
        {
            List<InventorExcel> datos = new List<InventorExcel>();
            await Task.Run(() =>
            {
                var archivo = new FileInfo(filePath);

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
            return datos;
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

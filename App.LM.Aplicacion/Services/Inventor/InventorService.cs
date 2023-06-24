using MiApp.LM.Dominio.Abstracciones;
using MiApp.LM.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.LM.Aplicacion.Services.Inventor
{
    public class InventorService : IIventorService
    {
        private List<string> columnasExcelInventor;
        private List<string> columnasTeoricas;
        private IInventorRepository _inventorRepository;
        private readonly ISettingRepository _settingRepository;

        public InventorService(IInventorRepository inventorRepository, ISettingRepository settingRepository)
        {
            _inventorRepository = inventorRepository;
            _settingRepository = settingRepository;
            columnasExcelInventor = new List<string>();
            columnasTeoricas = new List<string>();
        }

        public async Task<bool> VerificarColumnas(string ruta)
        {
            columnasExcelInventor = await CargarColumnasExcelInventor(ruta);
            columnasTeoricas = await CargarColumnasTeoricas();

            foreach (var col in columnasTeoricas)
            {
                if (!columnasExcelInventor.Contains(col)) return false;
            }
            return true; ;
        }
        public async Task<List<InventorExcel>> GetAllData(string ruta)
        {
            await _inventorRepository.LeerDatos(ruta);
            return _inventorRepository.DataExcel;
        }
        public async Task<List<string>> CargarColumnasExcelInventor(string ruta) => await _inventorRepository.EncabezadosExcel(ruta);
        public async Task<List<string>> CargarColumnasTeoricas() => await _settingRepository.GetAllColumnasInventor();

        public async Task<List<InventorExcel>> GetPerfiles()
        {
            List<InventorExcel> perfiles = new List<InventorExcel>();
            return perfiles;
        }
        public async Task<List<InventorExcel>> GetTornilleria()
        {
            List<InventorExcel> tornillera = new List<InventorExcel>();
            return tornillera;
        }
        public async Task<List<InventorExcel>> GetComerciales()
        {
            List<InventorExcel> comerciales = new List<InventorExcel>();
            return comerciales;
        }
        public async Task<List<InventorExcel>> GetMecanizdos()
        {
            List<InventorExcel> mecanizdos = new List<InventorExcel>();
            return mecanizdos;
        }
    }
}

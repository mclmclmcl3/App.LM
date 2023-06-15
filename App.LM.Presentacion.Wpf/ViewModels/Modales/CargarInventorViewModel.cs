using MiApp.LM.Dominio.Abstracciones;
using MiApp.LM.Dominio.Models;
using MiApp.LM.Infactustura.Repositories.RepositoriesExcel;
using MiApp.LM.Presentacion.Wpf.Models;
using MiApp.LM.Presentacion.Wpf.MVVM;
using Microsoft.Extensions.Configuration;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Telerik.Windows.Controls;

namespace MiApp.LM.Presentacion.Wpf.ViewModels.Modales
{
    public class CargarInventorViewModel : MVVM.ViewModelBase
    {
        public IInventorRepository _inventorRepository;
        private readonly IConfiguration configuration;
        private readonly ISettingRepository settingRepository;
        private List<string> columnasExcel;
        private List<string> columnasExcelTeoricas;
        //private ObservableCollection<InventorExcel> listaInventor;
        private Proyecto proyecto;
        private string ultimaRutaExcel;
        private Paginacion paginacion;


        #region Seleccion en los Combos
        private string comboElemento = string.Empty;
        public string ComboElemento
        {
            get { return comboElemento; }
            set { comboElemento = value; OnPropertyChanged(); }
        }

        private string comboCantidad = string.Empty;
        public string ComboCantidad
        {
            get { return comboCantidad; }
            set { comboCantidad = value; OnPropertyChanged(); }
        }

        private string comboNombre = string.Empty;
        public string ComboNombre
        {
            get { return comboNombre; }
            set { comboNombre = value; OnPropertyChanged(); }
        }

        private string comboDescripcion = string.Empty;
        public string ComboDescripcion
        {
            get { return comboDescripcion; }
            set { comboDescripcion = value; OnPropertyChanged(); }
        }

        private string comboCantidadUnidades = string.Empty;
        public string ComboCantidadUnidades
        {
            get { return comboCantidadUnidades; }
            set { comboCantidadUnidades = value; OnPropertyChanged(); }
        }

        private string comboMaterial = string.Empty;
        public string ComboMaterial
        {
            get { return comboMaterial; }
            set { comboMaterial = value; OnPropertyChanged(); }
        }

        private string comboCantidadElementos = string.Empty;
        public string ComboCantidadElementos
        {
            get { return comboCantidadElementos; }
            set { comboCantidadElementos = value; OnPropertyChanged(); }
        }

        private string comboMasa = string.Empty;
        public string ComboMasa
        {
            get { return comboMasa; }
            set { comboMasa = value; OnPropertyChanged(); }
        }

        private string comboArchivo = string.Empty;
        public string ComboArchivo
        {
            get { return comboArchivo; }
            set { comboArchivo = value; OnPropertyChanged(); }
        }

        private string comboProveedor = string.Empty;
        public string ComboProveedor
        {
            get { return comboProveedor; }
            set { comboProveedor = value; OnPropertyChanged(); }
        }

        private string comboTipo = string.Empty;
        public string ComboTipo
        {
            get { return comboTipo; }
            set { comboTipo = value; OnPropertyChanged(); }
        }
        #endregion


        public Paginacion Paginacion
        {
            get { return paginacion; }
            set
            {
                paginacion = value;
                OnPropertyChanged(nameof(Paginacion));
            }
        }
        public string UltimaRutaExcel
        {
            get
            {
                if (!string.IsNullOrEmpty(ultimaRutaExcel))
                    return ultimaRutaExcel;
                else
                {
                    ultimaRutaExcel = configuration["RutaExcelInventor"];
                    return ultimaRutaExcel;
                }
            }
            set
            {
                ultimaRutaExcel = value;
                configuration["RutaExcelInventor"] = value;
                OnPropertyChanged(nameof(UltimaRutaExcel));
            }
        }
        public Proyecto Proyecto
        {
            get { return proyecto; }
            set
            {
                proyecto = ProyectoActivo.GetInstancia.Proyecto;
                OnPropertyChanged(nameof(Proyecto));
            }
        }
        public List<string> ColumnasExcel
        {
            get => columnasExcel;
            set
            {
                columnasExcel = value;
                OnPropertyChanged(nameof(ColumnasExcel));
                UpdateCombos();
            }
        }
        public List<string> ColumnasExcelTeoricas
        {
            get => columnasExcelTeoricas;
            set { columnasExcelTeoricas = value; OnPropertyChanged(nameof(ColumnasExcelTeoricas)); }
        }

        public ICommand CargarExcel { get; set; }
        public ICommand GotoNextPageCommand { get; set; }
        public ICommand GotoPreviousPageCommand { get; set; }
        public ICommand GuardarCommand { get; set; }


        public CargarInventorViewModel(
            IInventorRepository inventorRepository,
            IConfiguration configuration,
            ISettingRepository settingRepository)
        {
            Paginacion = new Paginacion();

            //Paginacion.CurrentPage = 1;
            //Paginacion.PageSize = 10;

            //ListaInventor = new ObservableCollection<InventorExcel>();
            _inventorRepository = inventorRepository;
            this.configuration = configuration;
            this.settingRepository = settingRepository;

            // Cargo las columnas excel de appSetting.json
            // ColumnasExcelTeoricas = configuration.GetSection("ColumnasExcelInventor").Get<List<string>>();

            CargarExcel = new DelegateCommand(CargarArchivoExcel);
            GotoNextPageCommand = new DelegateCommand(GoToNextPage);
            GotoPreviousPageCommand = new DelegateCommand(GoToPreviousPage);
            GuardarCommand = new DelegateCommand(GuardarColumnasExcel);
        }

        private async void GuardarColumnasExcel(object obj)
        {
            List<string> columnas = new List<string>();
            columnas.Add(ComboElemento);
            columnas.Add(ComboCantidad);
            columnas.Add(ComboNombre);
            columnas.Add(ComboDescripcion);
            columnas.Add(ComboCantidadUnidades);
            columnas.Add(ComboMaterial);
            columnas.Add(ComboCantidadElementos);
            columnas.Add(ComboMasa);
            columnas.Add(ComboArchivo);
            columnas.Add(ComboProveedor);
            columnas.Add(ComboTipo);

            await settingRepository.UpdateColumnasInventor(columnas);
        }

        private async Task UpdateCombos()
        {
            var encabezados = await settingRepository.GetAllColumnasInventor();

            if (ColumnasExcel.Any(x => x.Contains(encabezados[0]))) ComboElemento = encabezados[0];
            if (ColumnasExcel.Any(x => x.Contains(encabezados[1]))) ComboCantidad = encabezados[1];
            if (ColumnasExcel.Any(x => x.Contains(encabezados[2]))) ComboNombre = encabezados[2];
            if (ColumnasExcel.Any(x => x.Contains(encabezados[3]))) ComboDescripcion = encabezados[3];
            if (ColumnasExcel.Any(x => x.Contains(encabezados[4]))) ComboCantidadUnidades = encabezados[4];
            if (ColumnasExcel.Any(x => x.Contains(encabezados[5]))) ComboMaterial = encabezados[5];
            if (ColumnasExcel.Any(x => x.Contains(encabezados[6]))) ComboCantidadElementos = encabezados[6];
            if (ColumnasExcel.Any(x => x.Contains(encabezados[7]))) ComboMasa = encabezados[7];
            if (ColumnasExcel.Any(x => x.Contains(encabezados[8]))) ComboArchivo = encabezados[8];
            if (ColumnasExcel.Any(x => x.Contains(encabezados[9]))) ComboProveedor = encabezados[9];
            if (ColumnasExcel.Any(x => x.Contains(encabezados[10]))) ComboTipo = encabezados[10];

            //if (ColumnasExcel.Any(x => x.Contains("Elemento"))) ComboElemento = "Elemento";
            //if (ColumnasExcel.Any(x => x.Contains("CTDAD"))) ComboCantidad = "CTDAD";
            //if (ColumnasExcel.Any(x => x.Contains("Nº de pieza"))) ComboNombre = "Nº de pieza";
            //if (ColumnasExcel.Any(x => x.Contains("Descripción"))) ComboDescripcion = "Descripción";
            //if (ColumnasExcel.Any(x => x.Contains("CTDAD de unidades"))) ComboCantidadUnidades = "CTDAD de unidades";
            //if (ColumnasExcel.Any(x => x.Contains("Material"))) ComboMaterial = "Material";
            //if (ColumnasExcel.Any(x => x.Contains("CTDAD de elementos"))) ComboCantidadElementos = "CTDAD de elementos";
            //if (ColumnasExcel.Any(x => x.Contains("Masa"))) ComboMasa = "Masa";
            //if (ColumnasExcel.Any(x => x.Contains("Nombre de archivo"))) ComboArchivo = "Nombre de archivo";
            //if (ColumnasExcel.Any(x => x.Contains("Proveedor"))) ComboProveedor = "Proveedor";
            //if (ColumnasExcel.Any(x => x.Contains("Tipo de componente"))) ComboTipo = "Tipo de componente";
        }
        private void GoToPreviousPage(object obj)
        {
            if (Paginacion.CurrentPage > 1)
            {
                Paginacion.CurrentPage--;
            }
        }
        private void GoToNextPage(object obj)
        {
            if (Paginacion.CurrentPage < Paginacion.TotalPages)
            {
                Paginacion.CurrentPage++;
            }
        }
        private async void CargarArchivoExcel(object t)
        {
            FileInfo Archivo = new FileInfo(UltimaRutaExcel);
            if (Archivo.Exists)
            {
                ColumnasExcel = await _inventorRepository.EncabezadosExcel(UltimaRutaExcel);
            }
            else
            {
                UltimaRutaExcel = string.Empty;
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Ardchivos de Excel (.xlsx)|*.xlsx";
                open.FilterIndex = 1;
                open.Multiselect = false;

                bool? seleccionOk = open.ShowDialog();
                if (seleccionOk == true)
                {
                    string filename = open.FileName;
                    UltimaRutaExcel = filename;

                    ColumnasExcel = await _inventorRepository.EncabezadosExcel(filename);
                }
            }
            ActualizarGrid();
        }
        private async void ActualizarGrid()
        {
            await _inventorRepository.LeerDatos(UltimaRutaExcel);
            var datos = _inventorRepository.DataExcel;
            //foreach (var dato in datos.OrderBy(x => x.Elemento))
            //{
            //    Paginacion.ListaInventor.Add(dato);
            //}
            Paginacion.ListaInventor = new ObservableCollection<InventorExcel>(datos.OrderBy(x => x.Elemento));
        }
    }
}

using MiApp.LM.Dominio.Abstracciones;
using MiApp.LM.Infactustura.Repositories.RepositoriesExcel;
using MiApp.LM.Presentacion.Wpf.Models;
using MiApp.LM.Presentacion.Wpf.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Telerik.Windows.Controls;
using TabControl = MiApp.LM.Presentacion.Wpf.Models.TabControl;

namespace MiApp.LM.Presentacion.Wpf.ViewModels.Modales
{
    public class LoadInvColumnasViewModels : MVVM.ViewModelBase
    {
        private readonly ISettingRepository settingRepository;
        public IInventorRepository _inventorRepository;
        private List<string> columnasExcel;
        private List<string> columnasExcelTeoricas;
        private string rutaExcel;
        private TabControl tabControl;
        private readonly LoadInvExcelViewModel loadInvExcelViewMode;

        public TabControl TabControl
        {
            get { return tabControl; }
            set { tabControl = value; OnPropertyChanged(nameof(TabControl.Tab)); }
        }
        public string RutaExcel
        {
            get { return rutaExcel; }
            set
            {
                rutaExcel = value;
                OnPropertyChanged(nameof(RutaExcel));
                UpdateCombos();
            }
        }
        public List<string> ColumnasExcel
        {
            get => columnasExcel;
            set
            {
                columnasExcel = value;
                OnPropertyChanged(nameof(ColumnasExcel));
            }
        }
        public List<string> ColumnasExcelTeoricas
        {
            get => columnasExcelTeoricas;
            set { columnasExcelTeoricas = value; OnPropertyChanged(nameof(ColumnasExcelTeoricas)); }
        }

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


        public ICommand GuardarCommand { get; set; }

        public LoadInvColumnasViewModels(IInventorRepository inventorRepository,
                                         ISettingRepository settingRepository,
                                         TabControl TabControl,
                                         LoadInvExcelViewModel loadInvExcelViewMode)
        {
            this.settingRepository = settingRepository;
            this._inventorRepository = inventorRepository;
            this.tabControl = TabControl;
            this.loadInvExcelViewMode = loadInvExcelViewMode;
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
            loadInvExcelViewMode.RutaExcel = RutaExcel;
            TabControl.VExcel = Visibilidad.Visible.ToString();
            TabControl.VColumnas = Visibilidad.Collapsed.ToString();
        }

        private async Task UpdateCombos()
        {
            ColumnasExcel = await _inventorRepository.EncabezadosExcel(RutaExcel);
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
        }
    }
}

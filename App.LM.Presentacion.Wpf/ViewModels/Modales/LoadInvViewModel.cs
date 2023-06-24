using MiApp.LM.Aplicacion.Services.Inventor;
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
    public class LoadInvViewModel : MVVM.ViewModelBase
    {
        public IInventorRepository _inventorRepository;
        private readonly IConfiguration configuration;
        private readonly ISettingRepository settingRepository;
        private readonly IIventorService _inventorService;
        private readonly LoadInvColumnasViewModels _loadInvColumnasViewModels;
        private readonly LoadInvPerfilesViewModel _loadInvPerfilesViewModel;
        private readonly LoadInvExcelViewModel _loadInvExcelViewModel;
        private Proyecto proyecto;
        private string rutaExcel;
        private TabControl tabControl;
        public TabControl TabControl
        {
            get { return tabControl; }
            set { tabControl = value; OnPropertyChanged(nameof(TabControl.Tab)); }
        }

        private List<string> columnasExcel;
        public List<string> ColumnasExcel
        {
            get => columnasExcel;
            set
            {
                columnasExcel = value;
                OnPropertyChanged(nameof(ColumnasExcel));
            }
        }
        public string RutaExcel
        {
            get { return rutaExcel; }
            set
            {
                rutaExcel = value;
                OnPropertyChanged(nameof(RutaExcel));
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



        public ICommand CargarExcel { get; set; }


        public LoadInvViewModel(
            IInventorRepository inventorRepository,
            IConfiguration configuration,
            ISettingRepository settingRepository,
            IIventorService inventorService,
            LoadInvColumnasViewModels loadInvColumnasViewModels,
            LoadInvPerfilesViewModel loadInvPerfilesViewModel,
            LoadInvExcelViewModel loadInvExcelViewModel,
            TabControl TabControl
            )
        {
            this.TabControl = TabControl;
            //Paginacion.CurrentPage = 1;
            //Paginacion.PageSize = 10;

            //ListaInventor = new ObservableCollection<InventorExcel>();
            _inventorRepository = inventorRepository;
            this.configuration = configuration;
            this.settingRepository = settingRepository;
            this._inventorService = inventorService;
            this._loadInvColumnasViewModels = loadInvColumnasViewModels;
            this._loadInvPerfilesViewModel = loadInvPerfilesViewModel;
            this._loadInvExcelViewModel = loadInvExcelViewModel;

            // Cargo las columnas excel de appSetting.json
            // ColumnasExcelTeoricas = configuration.GetSection("ColumnasExcelInventor").Get<List<string>>();

            CargarExcel = new DelegateCommand(CargarArchivoExcel);

        }


        private async void CargarArchivoExcel(object t)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Ardchivos de Excel (.xlsx)|*.xlsx";
            open.FilterIndex = 1;
            open.Multiselect = false;

            bool? seleccionOk = open.ShowDialog();
            if (seleccionOk == true)
            {
                string filename = open.FileName;
                RutaExcel = filename;

                //ColumnasExcel = await _inventorRepository.EncabezadosExcel(filename);
                //_loadInvExcelViewModel.RutaExcel = RutaExcel;
            }
            FileInfo fichero = new FileInfo(open.FileName);
            if (fichero.Exists)
            {
                RutaExcel = fichero.FullName;
                if (await _inventorService.VerificarColumnas(RutaExcel))
                {
                    TabControl.VExcel = Visibilidad.Visible.ToString();
                    TabControl.VColumnas = Visibilidad.Collapsed.ToString();
                    _loadInvExcelViewModel.RutaExcel = RutaExcel;
                }
                else
                {
                    TabControl.VExcel = Visibilidad.Collapsed.ToString();
                    TabControl.VColumnas = Visibilidad.Visible.ToString();
                    _loadInvColumnasViewModels.RutaExcel = RutaExcel;
                }
            }
        }

    }
}

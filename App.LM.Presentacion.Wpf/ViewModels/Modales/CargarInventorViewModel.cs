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
        private List<string> columnasExcel;
        private List<string> columnasExcelTeoricas;
        //private ObservableCollection<InventorExcel> listaInventor;
        private Proyecto proyecto;
        private string ultimaRutaExcel;
        private Paginacion paginacion;

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
        //public ObservableCollection<InventorExcel> ListaInventor
        //{
        //    get => listaInventor;
        //    set => listaInventor = value;
        //}
        public List<string> ColumnasExcel
        {
            get => columnasExcel;
            set { columnasExcel = value; OnPropertyChanged(nameof(ColumnasExcel)); }
        }
        public List<string> ColumnasExcelTeoricas
        {
            get => columnasExcelTeoricas;
            set { columnasExcelTeoricas = value; OnPropertyChanged(nameof(ColumnasExcelTeoricas)); }
        }

        public ICommand CargarExcel { get; set; }
        public ICommand GotoNextPageCommand { get; set; }
        public ICommand GotoPreviousPageCommand { get; set; }



        public CargarInventorViewModel(IInventorRepository inventorRepository, IConfiguration configuration)
        {
            Paginacion = new Paginacion();
            //Paginacion.CurrentPage = 1;
            //Paginacion.PageSize = 10;

            //ListaInventor = new ObservableCollection<InventorExcel>();
            _inventorRepository = inventorRepository;
            this.configuration = configuration;
            ColumnasExcelTeoricas = configuration.GetSection("ColumnasExcelInventor").Get<List<string>>();

            CargarExcel = new DelegateCommand(CargarArchivoExcel);
            GotoNextPageCommand = new DelegateCommand(GoToNextPage);
            GotoPreviousPageCommand = new DelegateCommand(GoToPreviousPage);
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
            Paginacion.ListaInventor = new ObservableCollection<InventorExcel>(datos.OrderBy(x=>x.Elemento));
        }
    }
}

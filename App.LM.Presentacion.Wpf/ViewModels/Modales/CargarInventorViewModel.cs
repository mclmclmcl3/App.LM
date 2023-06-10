using MiApp.LM.Dominio.Abstracciones;
using MiApp.LM.Dominio.Models;
using MiApp.LM.Infactustura.Repositories.RepositoriesExcel;
using MiApp.LM.Presentacion.Wpf.MVVM;
using Microsoft.Extensions.Configuration;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
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
        private ObservableCollection<InventorExcel> listaInventor;

        public ObservableCollection<InventorExcel> ListaInventor
        {
            get => listaInventor;
            set => listaInventor = value;
        }

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

        public CargarInventorViewModel(IInventorRepository inventorRepository, IConfiguration configuration)
        {
            _inventorRepository = inventorRepository;
            this.configuration = configuration;
            ListaInventor = new ObservableCollection<InventorExcel>();
            ColumnasExcelTeoricas = configuration.GetSection("ColumnasExcelInventor").Get<List<string>>();

            CargarExcel = new DelegateCommand(CargarArchivoExcel);
        }



        private void CargarArchivoExcel(object t)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Ardchivos de Excel (.xlsx)|*.xlsx";
            open.FilterIndex = 1;
            open.Multiselect = false;

            bool? seleccionOk = open.ShowDialog();
            if (seleccionOk == true)
            {
                string filename = open.FileName;

                _inventorRepository.LeerDatos(filename);
                var datos = _inventorRepository.DataExcel;
                foreach ( var dato in datos )
                {
                    ListaInventor.Add(dato);
                }
                ColumnasExcel = _inventorRepository.ColumnasExcel;
            }
        }
    }
}

using MiApp.LM.Dominio.Abstracciones;
using MiApp.LM.Dominio.Models;
using MiApp.LM.Presentacion.Wpf.Models;
using MiApp.LM.Presentacion.Wpf.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Telerik.Windows.Controls;

namespace MiApp.LM.Presentacion.Wpf.ViewModels.Modales
{
    public class LoadInvExcelViewModel : MVVM.ViewModelBase
    {
        private Paginacion paginacion;
        private string rutaExcel;
        private readonly IInventorRepository _inventorRepository;

        public string RutaExcel
        {
            get { return rutaExcel; }
            set
            {
                rutaExcel = value;
                OnPropertyChanged(nameof(RutaExcel));
                ActualizarGrid();
            }
        }
        public Paginacion Paginacion
        {
            get { return paginacion; }
            set
            {
                paginacion = value;
                OnPropertyChanged(nameof(Paginacion));
            }
        }
        public ICommand GotoNextPageCommand { get; set; }
        public ICommand GotoPreviousPageCommand { get; set; }

        public LoadInvExcelViewModel(IInventorRepository inventorRepository)
        {
            Paginacion = new Paginacion();
            GotoNextPageCommand = new DelegateCommand(GoToNextPage);
            GotoPreviousPageCommand = new DelegateCommand(GoToPreviousPage);
            this._inventorRepository = inventorRepository;
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
        private async void ActualizarGrid()
        {
            if(!RutaExcel.Equals(string.Empty))
            {
                await this._inventorRepository.LeerDatos(RutaExcel);
                var datos = _inventorRepository.DataExcel;
                Paginacion.ListaInventor = new ObservableCollection<InventorExcel>(datos.OrderBy(x => x.Elemento));
            }
        }
    }
}

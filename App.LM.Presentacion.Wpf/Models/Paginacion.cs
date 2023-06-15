using MiApp.LM.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.LM.Presentacion.Wpf.Models
{
    public class Paginacion : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Paginacion()
        {
            ListaInventor = new ObservableCollection<InventorExcel>();
            ListaInventorPaginada = new ObservableCollection<InventorExcel>();
            currentPage = 1;
            pageSize = 25;
        }

        private int currentPage;
        public int CurrentPage
        {
            get { return currentPage; }
            set
            {
                currentPage = value;
                OnPropertyChanged(nameof(CurrentPage));
                LoadData(); // Cargar los datos correspondientes a la página actual
            }
        }

        private int pageSize;
        public int PageSize
        {
            get { return pageSize; }
            set
            {
                pageSize = value;
                OnPropertyChanged(nameof(PageSize));
                LoadData(); // Cargar los datos correspondientes al cambio de tamaño de página
            }
        }

        private int totalItems;
        public int TotalItems
        {
            get { return totalItems; }
            set
            {
                totalItems = value;
                OnPropertyChanged(nameof(TotalItems));
                UpdateTotalPages();
            }
        }

        private int totalPages;
        public int TotalPages
        {
            get { return totalPages; }
            set
            {
                totalPages = value;
                OnPropertyChanged(nameof(TotalPages));
            }
        }

        private ObservableCollection<InventorExcel> listaInventor;
        public ObservableCollection<InventorExcel> ListaInventor
        {
            get => listaInventor;
            set
            {
                listaInventor = value;
                LoadData(); // Cargar los datos correspondientes al cambio de tamaño de página
            }
        }

        private ObservableCollection<InventorExcel> listaInventorPaginada;
        public ObservableCollection<InventorExcel> ListaInventorPaginada
        {
            get => listaInventorPaginada;
            set
            {
                listaInventorPaginada = value;
                OnPropertyChanged(nameof(ListaInventorPaginada));
            }
        }
        private ObservableCollection<InventorExcel> listaInventorPaginadaEjemplo;
        public ObservableCollection<InventorExcel> ListaInventorPaginadaEjemplo
        {
            get => listaInventorPaginadaEjemplo;
            set
            {
                listaInventorPaginadaEjemplo = value;
                OnPropertyChanged(nameof(ListaInventorPaginadaEjemplo));
            }
        }
        public void LoadData()
        {
            // Cargar los datos correspondientes a la página actual
            // Utiliza los valores de CurrentPage y PageSize en la consulta o filtrado
            // y actualiza la colección que se muestra en la vista

            TotalItems = listaInventor.Count;
            int startIndex = (CurrentPage - 1) * PageSize;
            int endIndex = startIndex + PageSize;

            ListaInventorPaginada = new ObservableCollection<InventorExcel>();
            ListaInventorPaginadaEjemplo = new ObservableCollection<InventorExcel>();

            var listado = ListaInventor.Skip(startIndex).Take(PageSize);
            var listadoEjemplo = ListaInventor.Skip(0).Take(5);


            foreach (var item in listadoEjemplo)
            {
                ListaInventorPaginadaEjemplo.Add(item);
            }

            foreach (var item in listado)
            {
                ListaInventorPaginada.Add(item);
            }
            var cant = ListaInventorPaginada.Count();
            // ListaInventorPaginada = new ObservableCollection<InventorExcel>(ListaInventor.Skip(startIndex).Take(PageSize));
        }

        private void UpdateTotalPages()
        {
            TotalPages = (int)Math.Ceiling((double)TotalItems / PageSize);
        }
    }
}

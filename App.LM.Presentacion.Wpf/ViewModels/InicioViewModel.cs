using MiApp.LM.Presentacion.Wpf.MVVM;
using MiApp.LM.Presentacion.Wpf.MVVM.Navegacion;
using System.Windows.Input;

namespace MiApp.LM.Presentacion.Wpf.ViewModels
{
    public class InicioViewModel : ViewModelBase
    {
        private readonly NavigationStore navigationStore;
        public ViewModelBase CurrentViewModel => navigationStore.CurrentViewModel;

        public ICommand IrEstadisticasCommand { get; set; }
        public ICommand IrListadoCommand { get; set; }
        public ICommand IrOfertasCommand { get; set; }
        public ICommand IrPedidosCommand { get; set; }
        public ICommand IrProyectosCommand { get; set; }

        public InicioViewModel(NavigationStore navigationStore)
        {
            this.navigationStore = navigationStore;
            IrEstadisticasCommand = new NavigateEstadisticasViewCommand(navigationStore);
            IrListadoCommand = new NavigateListadoViewCommand(navigationStore);
            IrOfertasCommand = new NavigateOfertasViewCommand(navigationStore);
            IrPedidosCommand = new NavigatePedidosViewCommand(navigationStore);
            IrProyectosCommand = new NavigateProyectosViewCommand(navigationStore);

            navigationStore.CurrentViewModel = new ProyectosViewModels(navigationStore);

            navigationStore.CurrentViewModelChanged += OnCurrentViewModelChange;
        }



        private void OnCurrentViewModelChange()
        {
            OnPropertyChange(nameof(CurrentViewModel));
        }
    }
}

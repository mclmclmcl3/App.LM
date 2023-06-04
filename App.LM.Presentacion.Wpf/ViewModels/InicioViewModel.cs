using MiApp.LM.Presentacion.Wpf.Mensajeria;
using MiApp.LM.Presentacion.Wpf.MVVM;
using MiApp.LM.Presentacion.Wpf.MVVM.Navegacion;
using SharpDX.Direct3D9;
using System.Security.Cryptography.Pkcs;
using System.Windows.Input;

namespace MiApp.LM.Presentacion.Wpf.ViewModels
{
    public class InicioViewModel : ViewModelBase
    {
        private readonly NavigationStore navigationStore;
        private EventUpdate eventUpdate;

        public ViewModelBase CurrentViewModel => navigationStore.CurrentViewModel;

        public ICommand IrEstadisticasCommand { get; set; }
        public ICommand IrListadoCommand { get; set; }
        public ICommand IrOfertasCommand { get; set; }
        public ICommand IrPedidosCommand { get; set; }
        public ICommand IrProyectosCommand { get; set; }

        public InicioViewModel(NavigationStore navigationStore, EventUpdate eventUpdate)
        {
            this.navigationStore = navigationStore;
            this.eventUpdate = eventUpdate;

            IrEstadisticasCommand = new NavigateEstadisticasViewCommand(navigationStore);
            IrListadoCommand = new NavigateListadoViewCommand(navigationStore);
            IrOfertasCommand = new NavigateOfertasViewCommand(navigationStore);
            IrPedidosCommand = new NavigatePedidosViewCommand(navigationStore);
            IrProyectosCommand = new NavigateProyectosViewCommand(navigationStore, eventUpdate);

            navigationStore.CurrentViewModel = new ProyectosViewModel(navigationStore, eventUpdate);

            navigationStore.CurrentViewModelChanged += OnCurrentViewModelChange;
        }



        private void OnCurrentViewModelChange()
        {
            OnPropertyChange(nameof(CurrentViewModel));
        }
    }
}

using MiApp.LM.Presentacion.Wpf.ViewModels;

namespace MiApp.LM.Presentacion.Wpf.MVVM.Navegacion
{
    class NavigatePedidosViewCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;

        public NavigatePedidosViewCommand(NavigationStore navigationStore )
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new MonoPantallaPedidosViewModels(_navigationStore);

            //VentanaDialogo vdialog = new VentanaDialogo("Home Dialogo");
            //vdialog.ShowDialog();
        }

    }
}

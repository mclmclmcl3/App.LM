using MiApp.LM.Presentacion.Wpf.ViewModels;

namespace MiApp.LM.Presentacion.Wpf.MVVM.Navegacion
{
    class NavigateOfertasViewCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;

        public NavigateOfertasViewCommand(NavigationStore navigationStore )
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new MonoPantallaOfertasViewModels(_navigationStore);

            //VentanaDialogo vdialog = new VentanaDialogo("Home Dialogo");
            //vdialog.ShowDialog();
        }

    }
}

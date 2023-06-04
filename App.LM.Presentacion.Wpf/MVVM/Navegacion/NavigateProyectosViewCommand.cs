using MiApp.LM.Presentacion.Wpf.ViewModels;

namespace MiApp.LM.Presentacion.Wpf.MVVM.Navegacion
{
    class NavigateProyectosViewCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;

        public NavigateProyectosViewCommand(NavigationStore navigationStore )
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new ProyectosViewModels(_navigationStore);

            //VentanaDialogo vdialog = new VentanaDialogo("Home Dialogo");
            //vdialog.ShowDialog();
        }

    }
}

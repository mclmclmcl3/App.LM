using MiApp.LM.Presentacion.Wpf.ViewModels;

namespace MiApp.LM.Presentacion.Wpf.MVVM.Navegacion
{
    class NavigateListadoViewCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        //private readonly string informacion;

        public NavigateListadoViewCommand(NavigationStore navigationStore )
        {
            _navigationStore = navigationStore;
            //this.informacion = informacion;
        }

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new ListadoViewModels(_navigationStore);

            //VentanaDialogo vdialog = new VentanaDialogo("Home Dialogo");
            //vdialog.ShowDialog();
        }

    }
}

using MiApp.LM.Presentacion.Wpf.Mensajeria;
using MiApp.LM.Presentacion.Wpf.ViewModels;

namespace MiApp.LM.Presentacion.Wpf.MVVM.Navegacion
{
    class NavigateListadoViewCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly EventUpdate eventUpdate;

        //private readonly string informacion;

        public NavigateListadoViewCommand(NavigationStore navigationStore, EventUpdate eventUpdate )
        {
            _navigationStore = navigationStore;
            this.eventUpdate = eventUpdate;
            //this.informacion = informacion;
        }

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new ListadoViewModel(_navigationStore, eventUpdate);

            //VentanaDialogo vdialog = new VentanaDialogo("Home Dialogo");
            //vdialog.ShowDialog();
        }

    }
}

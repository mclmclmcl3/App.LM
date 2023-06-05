using MiApp.LM.Presentacion.Wpf.Mensajeria;
using MiApp.LM.Presentacion.Wpf.ViewModels;

namespace MiApp.LM.Presentacion.Wpf.MVVM.Navegacion
{
    class NavigateProyectosViewCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly EventUpdate eventUpdate;

        public NavigateProyectosViewCommand(NavigationStore navigationStore, EventUpdate eventUpdate )
        {
            _navigationStore = navigationStore;
            this.eventUpdate = eventUpdate;
        }

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new ProyectosViewModel(_navigationStore, eventUpdate);

            //VentanaDialogo vdialog = new VentanaDialogo("Home Dialogo");
            //vdialog.ShowDialog();
        }

    }
}

using MiApp.LM.Presentacion.Wpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.LM.Presentacion.Wpf.MVVM.Navegacion
{
    class NavigateEstadisticasViewCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        //private readonly string informacion;

        public NavigateEstadisticasViewCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            //this.informacion = informacion;
        }

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new EstadisticasViewModel(_navigationStore);

            //VentanaDialogo vdialog = new VentanaDialogo("Home Dialogo");
            //vdialog.ShowDialog();
        }

    }
}

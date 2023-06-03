using MiApp.LM.Presentacion.Wpf.ViewModels;
using MiApp.LM.Presentacion.Wpf.Views.Modals;

namespace MiApp.LM.Presentacion.Wpf.MVVM.Navegacion.Modals
{
    public class NavegacionModificarProyectoCommand : CommandBase
    {
        private readonly MonoPantallaProyectosViewModels monoPantallaProyectosViewModels;

        public NavegacionModificarProyectoCommand(MonoPantallaProyectosViewModels monoPantallaProyectosViewModels)
        {
            this.monoPantallaProyectosViewModels = monoPantallaProyectosViewModels;
        }
        public override void Execute(object parameter)
        {
            if(parameter!=null)
            {
                ModalModificarProyectoView modal = new ModalModificarProyectoView(monoPantallaProyectosViewModels);
                modal.ShowDialog();
            }
        }
    }


}

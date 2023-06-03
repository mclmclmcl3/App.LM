using MiApp.LM.Presentacion.Wpf.ViewModels;
using MiApp.LM.Presentacion.Wpf.Views.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.LM.Presentacion.Wpf.MVVM.Navegacion.Modals
{
    public class NavegacionInsertarProyectoCommand : CommandBase
    {
        private readonly MonoPantallaProyectosViewModels monoPantallaProyectosViewModels;

        public NavegacionInsertarProyectoCommand(MonoPantallaProyectosViewModels monoPantallaProyectosViewModels)
        {
            this.monoPantallaProyectosViewModels = monoPantallaProyectosViewModels;
        }
        public override void Execute(object parameter)
        {
            //MessageBox.Show("Ventana para insertar");
            ModalsInsertarProyectoView modal = new ModalsInsertarProyectoView(monoPantallaProyectosViewModels);
            modal.ShowDialog();
        }
    }


}

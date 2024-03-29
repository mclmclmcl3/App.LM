﻿using MiApp.LM.Presentacion.Wpf.ViewModels;
using MiApp.LM.Presentacion.Wpf.Views.Modals;
using MiApp.LM.Presentacion.Wpf.Views.Modals.ModalProyectos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.LM.Presentacion.Wpf.MVVM.Navegacion.Modals
{
    public class NavegacionInsertarProyectoCommand : CommandBase
    {
        private readonly ProyectosViewModel monoPantallaProyectosViewModels;

        public NavegacionInsertarProyectoCommand(ProyectosViewModel monoPantallaProyectosViewModels)
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

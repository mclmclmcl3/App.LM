﻿using MiApp.LM.Presentacion.Wpf.ViewModels;
using MiApp.LM.Presentacion.Wpf.Views.Modals;

namespace MiApp.LM.Presentacion.Wpf.MVVM.Navegacion.Modals
{
    public class NavegacionCargarInventorCommand : CommandBase
    {
        private readonly ViewModelBase viewModel;

        public NavegacionCargarInventorCommand(ViewModelBase viewModel)
        {
            this.viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            CargarInventorView modal = new CargarInventorView();
            modal.ShowDialog();
        }
    }

}

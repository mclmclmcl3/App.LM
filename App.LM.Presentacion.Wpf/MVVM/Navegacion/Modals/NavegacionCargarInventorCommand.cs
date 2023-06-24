using MiApp.LM.Presentacion.Wpf.ViewModels;
using MiApp.LM.Presentacion.Wpf.Views.Modals;
using MiApp.LM.Presentacion.Wpf.Views.Modals.ModalCargaInventor;

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
            LoadInvView modal = new LoadInvView();
            modal.ShowDialog();
        }
    }

}

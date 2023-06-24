using MiApp.LM.Presentacion.Wpf.ViewModels.Modales;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace MiApp.LM.Presentacion.Wpf.Views.Modals.ModalCargaInventor
{
    public partial class LoadInvView
        : Window
    {
        private LoadInvViewModel viewmodel;
        public LoadInvView()
        {
            InitializeComponent();
            this.DataContext = viewmodel = App.AppHost.Services.GetRequiredService<LoadInvViewModel>();
        }


    }
}

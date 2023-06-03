using MiApp.LM.Presentacion.Wpf.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MiApp.LM.Presentacion.Wpf.Views
{
    /// <summary>
    /// Lógica de interacción para MonoPantallaProyectosPrincipalView.xaml
    /// </summary>
    public partial class MonoPantallaProyectosPrincipalView : UserControl
    {
        private MonoPantallaProyectosViewModels _viewmodel;

        public MonoPantallaProyectosPrincipalView()
        {
            InitializeComponent();
            this.DataContext = _viewmodel = App.AppHost.Services.GetRequiredService<MonoPantallaProyectosViewModels>();
        }
    }
}

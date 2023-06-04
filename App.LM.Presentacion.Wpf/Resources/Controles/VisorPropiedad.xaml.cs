using System.Windows;
using System.Windows.Controls;

namespace MiApp.LM.Presentacion.Wpf.Resources.Controles
{
    public partial class VisorPropiedad : UserControl
    {
        public VisorPropiedad()
        {
            InitializeComponent();
        }

        public int AnchoForm
        {
            get { return (int)GetValue(AnchoFormProperty); }
            set { SetValue(AnchoFormProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AnchoForm.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AnchoFormProperty =
            DependencyProperty.Register("AnchoForm", typeof(int), typeof(VisorPropiedad), new PropertyMetadata(0));

        public int AnchoNombre
        {
            get { return (int)GetValue(AnchoNombreProperty); }
            set { SetValue(AnchoNombreProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AnchoNombre.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AnchoNombreProperty =
            DependencyProperty.Register("AnchoNombre", typeof(int), typeof(VisorPropiedad), new PropertyMetadata(0));


        public string AlineacionHorizontal
        {
            get { return (string)GetValue(AlineacionHorizontalProperty); }
            set { SetValue(AlineacionHorizontalProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AlineacionHorizontal.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AlineacionHorizontalProperty =
            DependencyProperty.Register("AlineacionHorizontal", typeof(string), typeof(VisorPropiedad), new PropertyMetadata("Left"));

        public string TxtNombre
        {
            get { return (string)GetValue(TxtNombreProperty); }
            set { SetValue(TxtNombreProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TxtNombre.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TxtNombreProperty =
            DependencyProperty.Register("TxtNombre", typeof(string), typeof(VisorPropiedad), new PropertyMetadata(string.Empty));

        public string LblNombre
        {
            get { return (string)GetValue(LblNombreProperty); }
            set { SetValue(LblNombreProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LblNombre.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LblNombreProperty =
            DependencyProperty.Register("LblNombre", typeof(string), typeof(VisorPropiedad), new PropertyMetadata(string.Empty));


        public string Unidad
        {
            get { return (string)GetValue(UnidadProperty); }
            set { SetValue(UnidadProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Unidad.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UnidadProperty =
            DependencyProperty.Register("Unidad", typeof(string), typeof(VisorPropiedad), new PropertyMetadata("%"));

    }
}

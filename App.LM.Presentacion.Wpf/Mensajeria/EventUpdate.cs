using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.LM.Presentacion.Wpf.Mensajeria
{
    public class EventUpdate
    {
        public event Action ParameterPassed;
        public void PublishParameter()
        {
            ParameterPassed?.Invoke();
        }
    }
}

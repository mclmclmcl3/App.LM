using MiApp.LM.Presentacion.Wpf.Models;
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
        private MensajePiePagina mensajePiePagina;
        public MensajePiePagina MensajePiePagina { get => mensajePiePagina; set => mensajePiePagina = value; }
        public void PublishParameter()
        {
            ParameterPassed?.Invoke();
        }
    }
}

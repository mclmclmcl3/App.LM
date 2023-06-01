using System;

namespace MiApp.LM.Presentacion.Wpf.Mensajeria
{
    public class MensajePersona<T>
    {
        public event Action<T> ParameterPassed;
        public void PublishParameter(T obj)
        {
            ParameterPassed?.Invoke(obj);
        }
    }
}

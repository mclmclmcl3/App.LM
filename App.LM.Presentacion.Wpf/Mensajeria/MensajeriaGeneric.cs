using System;

namespace MiApp.LM.Presentacion.Wpf.Mensajeria
{
    public class MensajeriaGeneric<T>
    {
        public event Action<T> ParameterPassed;
        public void PublishParameter(T obj)
        {
            ParameterPassed?.Invoke(obj);
        }
    }
}

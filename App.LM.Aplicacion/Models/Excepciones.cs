using System;

namespace MiApp.LM.Aplicacion.Models
{
    public class Excepciones : Exception
    {
        public Excepciones() : base() { }
        public Excepciones(string mensaje) : base(mensaje) { }
        public Excepciones(string mensaje, Exception ex) : base(mensaje, ex) { }
    }
}

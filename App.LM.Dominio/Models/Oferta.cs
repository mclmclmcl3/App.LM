using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.LM.Dominio.Models
{
    public class Oferta
    {
        public int OfertaId { get; set; }
        public string NumeroOferta { get; set; }
        [ForeignKey(nameof(Elemento))]
        public int ElementoId { get; set; }

        // Relacion uno a uno con Elemento
        public virtual Elemento Elemento { get; set; }
    }
}

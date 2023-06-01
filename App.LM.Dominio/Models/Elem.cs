using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.LM.Dominio.Models
{
    public class Elem
    {
        public int ElemId { get; set; }
        public string NombreElemnto { get; set; }
        public double PrecioElemento { get; set; }
        public double Descuento { get; set; }

        // Relacion uno a muchos con Pedido
        [ForeignKey(nameof(Pedido))]
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }

        // Relacion uno a muchos con Oferta
        [ForeignKey(nameof(Oferta))]
        public int OfertaId { get; set; }
        public Oferta Oferta { get; set; }

    }
}

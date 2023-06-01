using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.LM.Dominio.Models
{
    public class Elemento
    {
        public int ElementoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Conjunto { get; set; }
        public string SubConjunto { get; set; }
        public string Comentario { get; set; }
        public string Estado { get; set; }
        public string ColoBg { get; set; } // Según estado
        public string Fabricante { get; set; } // Después de pedido
        public string Proveedor { get; set; } // Después de pedido
        public double Precio { get; set; } // Después de pedido

        // Relacion uno a muchos con Oferta
        public List<Oferta> Ofertas { get; set; }

        // Relacion uno a uno con Nodo
        [ForeignKey(nameof(Nodo))]
        public int NodoId { get; set; }
        public Nodo Nodo { get; set; }


        // Relacion uno a muchos con Proyecto
        [ForeignKey(nameof(Proyecto))]
        public int ProyectoId { get; set; }
        public Proyecto Proyecto { get; set; }


        // Relacion uno a uno con Pedido
        [ForeignKey(nameof(Pedido))]
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.LM.Dominio.Models
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public string NumeroPedido { get; set; }

        // Relacion uno a muchos con Elem
        public List<Elem> Elementos { get; set; }

        // Relacion uno a uno con Elemento
        public Elemento Elemento { get; set; }
    }
}

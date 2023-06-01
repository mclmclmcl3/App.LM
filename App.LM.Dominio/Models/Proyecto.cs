using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace App.LM.Dominio.Models
{
    public class Proyecto
    {
        public int ProyectoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        // Relacion uno a muchos con Elemento
        [ForeignKey(nameof(Elemento))]
        public List<Elemento> Elementos { get; set; }
    }
}

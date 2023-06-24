using System.ComponentModel.DataAnnotations.Schema;

namespace MiApp.LM.Dominio.Models
{
    public class SubTipo
    {
        public int SubTipoId { get; set; }
        public string Nombre { get; set; }

        [ForeignKey(nameof(Tipo))]
        public int TipoId { get; set; }
        public virtual Tipo Tipo { get; set; }
    }
}

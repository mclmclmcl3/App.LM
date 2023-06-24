using MiApp.LM.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.LM.Aplicacion.Models
{
    public class InventorExcelDto : InventorExcel
    {
        public Color Fondo { get; set; }
        public Color Texto { get; set; }
    }
}

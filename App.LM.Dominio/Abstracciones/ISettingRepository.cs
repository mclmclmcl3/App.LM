using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.LM.Dominio.Abstracciones
{
    public interface ISettingRepository
    {
        Task BorrarRutaMaestro();
        Task DelAllColumnasInventor();
        Task<List<string>> GetAllColumnasInventor();
        Task<string> GetRutaMaestro();
        Task UpdateColumnasInventor(List<string> datosNuevos);
        Task UpdatetRutaMaestro(string rutaNuevaMaestro);
    }
}

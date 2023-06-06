using MiApp.LM.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.LM.Infactustura.Conexion
{
    public class ConexionSqlite : DbContext
    {
        private string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\Setting.db3");

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($@"Data Source={ruta}");
            SQLitePCL.Batteries.Init();

            // To be disabled in production 
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.EnableDetailedErrors();

            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Elemento> Elementos { get; set; }
        public DbSet<Nodo> Nodos { get; set; }
        public DbSet<Oferta> Ofertas { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Elem> Elems { get; set; }
    }
}

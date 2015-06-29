using Agiledw.SiSWeb.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agiledw.SiSWeb.Dominio.Repositorio
{
    public class EfDbContext : DbContext
    {
        public DbSet<Entidades.Administrador> Administradores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Entidades.Administrador>().ToTable("Administradores");
        }

        //Atualizar Database automaticamente
        //public EfDbContext()
        //{
        //    Database.SetInitializer(new MigrateDatabaseToLatestVersion<EfDbContext, Configuration>());
        //}
    }
}

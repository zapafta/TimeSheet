
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DataAccess
{
    public class ApplicationDbContext : DbContext
    {


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
  : base(options)
        {


        }


        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Localizacao> Localizacao { get; set; }
        public virtual DbSet<TipoServico> TipoServico { get; set; }
        public virtual DbSet<HistoricoLocalizacao> HistoricoLocalizacao { get; set; }

        public virtual DbSet<Colaborador> Colaborador { get; set; }
        public virtual DbSet<Evento> Evento { get; set; }

        public virtual DbSet<ColaboradorXTipoServico> ColaboradorXTipoServico { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {

            modelBuilder.Entity<ColaboradorXTipoServico>()
       .HasKey(c => new { c.IdColaborador, c.IdTipoServico });

            modelBuilder.Entity<ColaboradorXTipoServico>()
                .HasOne(bc => bc.Colaborador);


            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
.SelectMany(t => t.GetForeignKeys())
.Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;





            base.OnModelCreating(modelBuilder);
        }




    }
}

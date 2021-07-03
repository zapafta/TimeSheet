
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


        public virtual DbSet<Person> Person { get; set; }
      



        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {


            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
.SelectMany(t => t.GetForeignKeys())
.Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;





            base.OnModelCreating(modelBuilder);
        }




    }
}

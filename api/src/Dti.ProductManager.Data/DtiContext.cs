using Dti.ProductManager.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Dti.ProductManager.Data
{
    public class DtiContext : DbContext
    {
        public DbSet<Produto> Produto { get; set; }

        public DtiContext(DbContextOptions<DtiContext> options) :
           base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(e => e.Nome).IsRequired();
                entity.Property(e => e.Valor).IsRequired();
            });
        }
    }
}
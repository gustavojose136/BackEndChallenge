using Microsoft.EntityFrameworkCore;
using Reviews.Models;

namespace Reviews.Data
{
    public class DepoimentoContext : DbContext
    {
        public DepoimentoContext(DbContextOptions<DepoimentoContext> options) 
            : base(options)
        {
        }

        public DbSet<Depoimento> Depoimentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Map.DepoimentoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}

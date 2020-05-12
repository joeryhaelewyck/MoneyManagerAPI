using Microsoft.EntityFrameworkCore;
using MoneyManagerApi.Data.Mappers;
using MoneyManagerApi.Models;

namespace MoneyManagerApi.Data
{
    public class TransactionContext : DbContext
    {
        public TransactionContext(DbContextOptions<TransactionContext> options) : base(options) 
        { 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CostConfiguration());

            modelBuilder.Entity<Cost>().HasData(
                   new Cost { Id = 1, Name = "DansLessen", Type = "Maandelijks", Amount = 50m},
                   new Cost { Id = 2, Name = "netflix", Type = "Maandelijks", Amount = 12m},
                   new Cost { Id = 3, Name = "booschappn", Type = "eenmalig", Amount = 69.60m }
                );
        }
        public DbSet<Cost> Costs { get; set; }
    }
}

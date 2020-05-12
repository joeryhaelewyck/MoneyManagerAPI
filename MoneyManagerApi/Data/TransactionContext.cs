using Microsoft.EntityFrameworkCore;
using MoneyManagerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManagerApi.Data
{
    public class TransactionContext : DbContext
    {
        public TransactionContext(DbContextOptions<TransactionContext> options)
            : base(options) 
        { 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cost>()
                .Property(c => c.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Cost>()
                .Property(c => c.Type).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Cost>()
                .Property(c => c.Amount).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<Cost>().HasData(
                   new Cost { Id = 1, Name = "Dans Lessen", Type = "Maandelijks", Amount = 50},
                   new Cost { Id = 2, Name = "netflix", Type = "Maandelijks", Amount = 12},
                   new Cost { Id = 3, Name = "booschappn", Type = "eenmalig", Amount = 69.60m }
                );
        }
        public DbSet<Cost> Costs { get; set; }
    }
}

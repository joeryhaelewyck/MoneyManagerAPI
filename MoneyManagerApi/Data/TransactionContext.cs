using Microsoft.EntityFrameworkCore;
using MoneyManagerApi.Data.Mappers;
using MoneyManagerApi.Models;
using System;

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
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            modelBuilder.Entity<Transaction>().HasData(
                   new Transaction { Id = 1, Name = "DansLessen", Type = Frequency.monthly, Amount = 50m, TransactionDateTime = new DateTime(2020,1,18)},
                   new Transaction { Id = 2, Name = "netflix", Type = Frequency.monthly, Amount = 12m, TransactionDateTime = new DateTime(2020, 1, 18) },
                   new Transaction { Id = 3, Name = "booschappn", Type = Frequency.oneOff, Amount = 69.60m, TransactionDateTime = new DateTime(2020, 1, 18) }
                );
        }
        public DbSet<Transaction> Transactions { get; set; }
    }
}

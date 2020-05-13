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
                   new Transaction { Id = 1, Name = "black money", FrequencyTransaction = Frequency.Monthly, Amount = 50m, TransactionDateTime = new DateTime(2020,1,18)},
                   new Transaction { Id = 2, Name = "TUI", FrequencyTransaction = Frequency.Monthly, Amount = 12m, TransactionDateTime = new DateTime(2020, 1, 18) },
                   new Transaction { Id = 3, Name = "boodschappn", FrequencyTransaction = Frequency.OneOff, Amount = -69.60m, TransactionDateTime = new DateTime(2020, 1, 18) },
                   new Transaction { Id = 4, Name = "netflix", FrequencyTransaction = Frequency.Monthly, Amount = -29.60m, TransactionDateTime = new DateTime(2020, 1, 18) }
                );
        }
        public DbSet<Transaction> Transactions { get; set; }
    }
}

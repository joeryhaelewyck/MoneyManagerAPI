using Microsoft.EntityFrameworkCore;
using MoneyManagerApi.Data.Mappers;
using MoneyManagerApi.Models;
using System;

namespace MoneyManagerApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            modelBuilder.Entity<Transaction>().HasData(
                   new Transaction { Id = 1, Name = "Black money", Type = TypeTransaction.Income, Amount = 50m, TransactionDateTime = new DateTime(2020,1,18)},
                   new Transaction { Id = 2, Name = "Dance Lesson", Type = TypeTransaction.Cost, Amount = -20.50m, TransactionDateTime = new DateTime(2020, 7, 30) },
                   new Transaction { Id = 3, Name = "Grocery", Type = TypeTransaction.Cost, Amount = -69.60m, TransactionDateTime = new DateTime(2020, 4, 18) },
                   new Transaction { Id = 4, Name = "netflix", Type = TypeTransaction.Cost, Amount = -12.60m, TransactionDateTime = new DateTime(2020, 8, 10) },
                   new Transaction { Id = 5, Name = "Salary", Type = TypeTransaction.Income, Amount = 2100.60m, TransactionDateTime = new DateTime(2020, 8, 01) }
                );
        }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

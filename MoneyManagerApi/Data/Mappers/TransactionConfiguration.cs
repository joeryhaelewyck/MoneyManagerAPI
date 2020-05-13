using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyManagerApi.Models;

namespace MoneyManagerApi.Data.Mappers
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            //table name
            builder.ToTable("Transactions");
            //Primary key
            builder.HasKey(T => T.Id);
            //Properties
            builder.Property(T => T.Name).HasColumnName("NAME").IsRequired();
            builder.Property(T => T.FrequencyTransaction).HasColumnName("FREQUENCY").IsRequired();
            builder.Property(T => T.Amount).HasColumnName("AMOUNT").IsRequired();
            builder.Property(T => T.TransactionDateTime).HasColumnName("DATE").IsRequired();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyManagerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManagerApi.Data.Mappers
{
    public class CostConfiguration : IEntityTypeConfiguration<Cost>
    {
        public void Configure(EntityTypeBuilder<Cost> builder)
        {
            //table name
            builder.ToTable("Costs");
            //Primary key
            builder.HasKey(C => C.Id);
            //Properties
            builder.Property(C => C.Name).HasColumnName("NAME").IsRequired();
            builder.Property(C => C.Type).HasColumnName("TYPE").IsRequired();
            builder.Property(C => C.Amount).HasColumnName("Amount").IsRequired();
        }
    }
}

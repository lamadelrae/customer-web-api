using CustomerWebApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerWebApi.Infrastructure.Data.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer", "dbo");

            builder.Property(x => x.Id)
                .HasColumnType("UNIQUEIDENTIFIER")
                .HasColumnName("Id")
                .IsRequired();

            builder.HasIndex(x => x.Id)
                .IsUnique();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("VARCHAR(30)")
                .HasColumnName("Name");

            builder.Property(x => x.Cpf)
                .IsRequired()
                .HasColumnType("VARCHAR(11)")
                .HasColumnName("CPF");

            builder.Property(x => x.BirthDate)
                .IsRequired()
                .HasColumnType("DATE")
                .HasColumnName("BirthDate");

            builder.HasMany(x => x.Addresses)
                .WithOne(x => x.Customer)
                .HasForeignKey(x => x.CustomerId);
        }
    }
}

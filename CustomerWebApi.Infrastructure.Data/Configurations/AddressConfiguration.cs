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
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address", "dbo");

            builder.Property(x => x.Id)
                .HasColumnType("UNIQUEIDENTIFIER")
                .HasColumnName("Id")
                .IsRequired();

            builder.HasIndex(x => x.Id)
                .IsUnique();

            builder.Property(x => x.CustomerId)
                .IsRequired()
                .HasColumnType("UNIQUEIDENTIFIER")
                .HasColumnName("CustomerId");

            builder.Property(x => x.District)
                .IsRequired()
                .HasColumnType("VARCHAR(40)")
                .HasColumnName("District");

            builder.Property(x => x.Street)
                .IsRequired()
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("Street");

            builder.Property(x => x.City)
                .IsRequired()
                .HasColumnType("VARCHAR(40)")
                .HasColumnName("City");

            builder.Property(x => x.State)
                .IsRequired()
                .HasColumnType("VARCHAR(40)")
                .HasColumnName("State");
        }
    }
}

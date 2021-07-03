using CustomerWebApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerWebApi.Infrastructure.Data.Database
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=Localhost\SQL2019;Database=CustomerApi;User Id=sa;Password=pass123;");
        }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<Address> Address { get; set; }
    }
}
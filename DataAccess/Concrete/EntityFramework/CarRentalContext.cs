using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class CarRentalContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=CarRental; Integrated Security=True");
        }
        public DbSet<Cars> Cars { get; set; }
        public DbSet<Colors> Colors { get; set; }
        public DbSet<Brands> Brands { get; set; }
    }
}

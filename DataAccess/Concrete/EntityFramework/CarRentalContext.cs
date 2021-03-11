using Core.Entites.Concrete;
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
        public DbSet<CarImages> CarImages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim>  OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<Customers> Customer { get; set; }
        public DbSet<Rentals> Rentals { get; set; }
    }
}

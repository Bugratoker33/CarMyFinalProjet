using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class RentACarContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-FCRUI1S;Initial Catalog=RentACar; Integrated Security=True;Encrypt=False;");
        }

        // optionsBuilder.UseSqlServer("Data Source=DESKTOP-FCRUI1S;Initial Catalog=RentACar; Integrated Security=True;Encrypt=False;");


        public DbSet<Car> Car { get; set; }

        public DbSet<Color> Colour { get; set; }

        public DbSet<Brand> Brand { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Rental> Rental { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }



        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //  modelBuilder.Entity<Color>().ToTable("Colour");
        /// burada isimlendirmesi farklı olan sınıflarla birleştirmek için yaptık:::.::

        //}

    }
}

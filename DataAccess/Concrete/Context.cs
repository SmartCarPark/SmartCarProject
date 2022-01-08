using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-N7NUFR1;Database=SmartCarPark;Trusted_Connection=true");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Park> Parks { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Spot> Spots { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Incubation.DAL.Entities;
using Incubation.DAL.Entities.BookingAggregate;
using Incubation.DAL.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Incubation.DAL.Data
{
    public class IncubationContext : IdentityDbContext<AppUser>
    {
        public IncubationContext(DbContextOptions<IncubationContext> options) : base(options)
        {

        }
        public DbSet<Incubator> incubators { get; set; }
        public DbSet<Bed> beds { get; set; }
        public DbSet<Admin> admins { get; set; }
        public DbSet<Doctor> doctors { get; set; }
        public DbSet<UserData> userDatas { get; set; }

        public DbSet<Booking> bookings { get; set; }
        public DbSet<ChildData> ChildDatas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUser>().Ignore(x => x.PhoneNumber);
            modelBuilder.Entity<AppUser>().Ignore(x => x.PhoneNumberConfirmed);
            
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.BedData)
                .WithMany(b=>b.Bookings)
                .HasForeignKey(b => b.bedid)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.ChildData)
                .WithMany(b => b.bookings)
                .HasForeignKey(b => b.childId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //modelBuilder.Entity<Booking>()
            //.Ignore(b => b.ChildData);


        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using DataAccessLayer.Entities;
using System;
using System.Linq;

namespace DataAccessLayer
{
    public class HotelDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<RoomInformation> RoomInformations { get; set; }
        public DbSet<BookingReservation> BookingReservations { get; set; }
        public DbSet<BookingDetail> BookingDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                string connString = config.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure primary key for BookingDetail (composite key)
            modelBuilder.Entity<BookingDetail>()
                .HasKey(bd => new { bd.BookingReservationID, bd.RoomID });
            
            // Configure table names explicitly
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<RoomType>().ToTable("RoomType");
            modelBuilder.Entity<RoomInformation>().ToTable("RoomInformation");
            modelBuilder.Entity<BookingReservation>().ToTable("BookingReservation");
            modelBuilder.Entity<BookingDetail>().ToTable("BookingDetail");
            
            // Configure relationships
            modelBuilder.Entity<BookingDetail>()
                .HasOne(bd => bd.BookingReservation)
                .WithMany(br => br.BookingDetails)
                .HasForeignKey(bd => bd.BookingReservationID);
                
            modelBuilder.Entity<BookingDetail>()
                .HasOne(bd => bd.RoomInformation)
                .WithMany(ri => ri.BookingDetails)
                .HasForeignKey(bd => bd.RoomID);
                
            modelBuilder.Entity<BookingReservation>()
                .HasOne(br => br.Customer)
                .WithMany(c => c.BookingReservations)
                .HasForeignKey(br => br.CustomerID);
                
            modelBuilder.Entity<RoomInformation>()
                .HasOne(ri => ri.RoomType)
                .WithMany(rt => rt.RoomInformations)
                .HasForeignKey(ri => ri.RoomTypeID);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
namespace HotelApi.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HotelDbContext : DbContext
    {
        public HotelDbContext()
            : base("name=HotelDbContext")
        {
        }

        public virtual DbSet<Hotel> Hotel { get; set; }
        public virtual DbSet<HotelBuchung> HotelBuchung { get; set; }
        public virtual DbSet<Region> Region { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>()
                .Property(e => e.Bezeichnung)
                .IsUnicode(false);

            modelBuilder.Entity<Hotel>()
                .Property(e => e.BildPfad)
                .IsUnicode(false);

            modelBuilder.Entity<Hotel>()
                .Property(e => e.LastUpdate)
                .IsFixedLength();

            modelBuilder.Entity<Hotel>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Hotel>()
                .Property(e => e.Preis)
                .HasPrecision(6, 2);

            modelBuilder.Entity<Hotel>()
                .HasMany(e => e.HotelBuchung)
                .WithRequired(e => e.Hotel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HotelBuchung>()
                .Property(e => e.Vorname)
                .IsUnicode(false);

            modelBuilder.Entity<HotelBuchung>()
                .Property(e => e.Nachname)
                .IsUnicode(false);

            modelBuilder.Entity<HotelBuchung>()
                .Property(e => e.Preis)
                .HasPrecision(6, 2);

            modelBuilder.Entity<Region>()
                .Property(e => e.Bezeichnung)
                .IsUnicode(false);

            modelBuilder.Entity<Region>()
                .Property(e => e.LastUpdate)
                .IsFixedLength();

            modelBuilder.Entity<Region>()
                .HasMany(e => e.Hotel)
                .WithRequired(e => e.Region)
                .WillCascadeOnDelete(false);
        }
    }
}

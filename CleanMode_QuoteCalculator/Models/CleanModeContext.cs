using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CleanMode_QuoteCalculator.Models
{
    public partial class CleanModeContext : DbContext
    {
        public CleanModeContext()
        {
        }

        public CleanModeContext(DbContextOptions<CleanModeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Basement> Basements { get; set; }
        public virtual DbSet<Bathroom> Bathrooms { get; set; }
        public virtual DbSet<Bedroom> Bedrooms { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Diningroom> Diningrooms { get; set; }
        public virtual DbSet<Entrance> Entrances { get; set; }
        public virtual DbSet<Garage> Garages { get; set; }
        public virtual DbSet<Kitchen> Kitchens { get; set; }
        public virtual DbSet<Livingroom> Livingrooms { get; set; }
        public virtual DbSet<Quote> Quotes { get; set; }
        public virtual DbSet<QuoteRoomType> QuoteRoomTypes { get; set; }
        public virtual DbSet<RoomType> RoomTypes { get; set; }
        public virtual DbSet<Stair> Stairs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=cleanMode;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Basement>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("basement");

                entity.Property(e => e.PricePerSqft).HasColumnName("price_per_sqft");

                entity.Property(e => e.RoomTypeId).HasColumnName("roomType_id");

                entity.HasOne(d => d.RoomType)
                    .WithMany()
                    .HasForeignKey(d => d.RoomTypeId)
                    .HasConstraintName("FK__basement__roomTy__35BCFE0A");
            });

            modelBuilder.Entity<Bathroom>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("bathrooms");

                entity.Property(e => e.PricePerSqft).HasColumnName("price_per_sqft");

                entity.Property(e => e.RoomTypeId).HasColumnName("roomType_id");

                entity.HasOne(d => d.RoomType)
                    .WithMany()
                    .HasForeignKey(d => d.RoomTypeId)
                    .HasConstraintName("FK__bathrooms__roomT__300424B4");
            });

            modelBuilder.Entity<Bedroom>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("bedrooms");

                entity.Property(e => e.PricePerSqft).HasColumnName("price_per_sqft");

                entity.Property(e => e.RoomTypeId).HasColumnName("roomType_id");

                entity.HasOne(d => d.RoomType)
                    .WithMany()
                    .HasForeignKey(d => d.RoomTypeId)
                    .HasConstraintName("FK__bedrooms__roomTy__2C3393D0");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customers");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email_address");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.PhysicalAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("physical_address");
            });

            modelBuilder.Entity<Diningroom>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("diningroom");

                entity.Property(e => e.PricePerSqft).HasColumnName("price_per_sqft");

                entity.Property(e => e.RoomTypeId).HasColumnName("roomType_id");

                entity.HasOne(d => d.RoomType)
                    .WithMany()
                    .HasForeignKey(d => d.RoomTypeId)
                    .HasConstraintName("FK__diningroo__roomT__398D8EEE");
            });

            modelBuilder.Entity<Entrance>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("entrance");

                entity.Property(e => e.PricePerSqft).HasColumnName("price_per_sqft");

                entity.Property(e => e.RoomTypeId).HasColumnName("roomType_id");

                entity.HasOne(d => d.RoomType)
                    .WithMany()
                    .HasForeignKey(d => d.RoomTypeId)
                    .HasConstraintName("FK__entrance__roomTy__33D4B598");
            });

            modelBuilder.Entity<Garage>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("garage");

                entity.Property(e => e.PricePerSqft).HasColumnName("price_per_sqft");

                entity.Property(e => e.RoomTypeId).HasColumnName("roomType_id");

                entity.HasOne(d => d.RoomType)
                    .WithMany()
                    .HasForeignKey(d => d.RoomTypeId)
                    .HasConstraintName("FK__garage__roomType__37A5467C");
            });

            modelBuilder.Entity<Kitchen>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("kitchens");

                entity.Property(e => e.PricePerSqft).HasColumnName("price_per_sqft");

                entity.Property(e => e.RoomTypeId).HasColumnName("roomType_id");

                entity.HasOne(d => d.RoomType)
                    .WithMany()
                    .HasForeignKey(d => d.RoomTypeId)
                    .HasConstraintName("FK__kitchens__roomTy__31EC6D26");
            });

            modelBuilder.Entity<Livingroom>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("livingrooms");

                entity.Property(e => e.PricePerSqft).HasColumnName("price_per_sqft");

                entity.Property(e => e.RoomTypeId).HasColumnName("roomType_id");

                entity.HasOne(d => d.RoomType)
                    .WithMany()
                    .HasForeignKey(d => d.RoomTypeId)
                    .HasConstraintName("FK__livingroo__roomT__2E1BDC42");
            });

            modelBuilder.Entity<Quote>(entity =>
            {
                entity.ToTable("quotes");

                entity.Property(e => e.QuoteId).HasColumnName("quote_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.Quote1).HasColumnName("quote");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Quotes)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__quotes__customer__25869641");
            });

            modelBuilder.Entity<QuoteRoomType>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("quoteRoomTypes");

                entity.Property(e => e.QuoteId).HasColumnName("quote_id");

                entity.Property(e => e.RoomTypeId).HasColumnName("roomType_id");

                entity.HasOne(d => d.Quote)
                    .WithMany()
                    .HasForeignKey(d => d.QuoteId)
                    .HasConstraintName("FK__quoteRoom__quote__29572725");

                entity.HasOne(d => d.RoomType)
                    .WithMany()
                    .HasForeignKey(d => d.RoomTypeId)
                    .HasConstraintName("FK__quoteRoom__roomT__2A4B4B5E");
            });

            modelBuilder.Entity<RoomType>(entity =>
            {
                entity.ToTable("roomTypes");

                entity.Property(e => e.RoomTypeId).HasColumnName("roomType_id");

                entity.Property(e => e.RoomType1)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("roomType");
            });

            modelBuilder.Entity<Stair>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("stairs");

                entity.Property(e => e.PricePerSqft).HasColumnName("price_per_sqft");

                entity.Property(e => e.RoomTypeId).HasColumnName("roomType_id");

                entity.HasOne(d => d.RoomType)
                    .WithMany()
                    .HasForeignKey(d => d.RoomTypeId)
                    .HasConstraintName("FK__stairs__roomType__3B75D760");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

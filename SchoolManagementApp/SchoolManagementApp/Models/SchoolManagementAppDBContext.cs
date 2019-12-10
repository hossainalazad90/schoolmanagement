using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SchoolManagementApp.Models
{
    public partial class SchoolManagementAppDBContext : DbContext
    {
        public SchoolManagementAppDBContext()
        {
        }

        public SchoolManagementAppDBContext(DbContextOptions<SchoolManagementAppDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Currencies> Currencies { get; set; }
        public virtual DbSet<Districts> Districts { get; set; }
        public virtual DbSet<States> States { get; set; }
        public virtual DbSet<UnionPorisods> UnionPorisods { get; set; }
        public virtual DbSet<Upazilas> Upazilas { get; set; }
        public virtual DbSet<Villages> Villages { get; set; }
        public virtual DbSet<Wards> Wards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=SchoolManagementAppDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId })
                    .HasName("PK_dbo.AspNetUserLogins");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PK_dbo.AspNetUserRoles");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.RoleId).HasMaxLength(128);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.Property(e => e.Area).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Capital).HasMaxLength(50);

                entity.Property(e => e.Isocode2)
                    .HasColumnName("ISOCode2")
                    .HasMaxLength(2);

                entity.Property(e => e.Isocode3)
                    .HasColumnName("ISOCode3")
                    .HasMaxLength(3);

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.Countries)
                    .HasForeignKey(d => d.CurrencyId)
                    .HasConstraintName("FK_dbo.Countries_dbo.Currencies_CurrencyId");
            });

            modelBuilder.Entity<Currencies>(entity =>
            {
                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.Symbol).HasMaxLength(50);

                entity.Property(e => e.UsdollarValue)
                    .HasColumnName("USDollarValue")
                    .HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Districts>(entity =>
            {
                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Districts)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK_dbo.Districts_dbo.States_StateId");
            });

            modelBuilder.Entity<States>(entity =>
            {
                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.States)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_dbo.States_dbo.Countries_CountryId");
            });

            modelBuilder.Entity<UnionPorisods>(entity =>
            {
                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.Upazila)
                    .WithMany(p => p.UnionPorisods)
                    .HasForeignKey(d => d.UpazilaId)
                    .HasConstraintName("FK_dbo.UnionPorisods_dbo.Upazilas_UpazilaId");
            });

            modelBuilder.Entity<Upazilas>(entity =>
            {
                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.District)
                    .WithMany(p => p.Upazilas)
                    .HasForeignKey(d => d.DistrictId)
                    .HasConstraintName("FK_dbo.Upazilas_dbo.States_StateId");
            });

            modelBuilder.Entity<Villages>(entity =>
            {
                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.UnionPorisod)
                    .WithMany(p => p.Villages)
                    .HasForeignKey(d => d.UnionPorisodId)
                    .HasConstraintName("FK_dbo.Villages_dbo.UnionPorisods_UnionPorisodId");
            });

            modelBuilder.Entity<Wards>(entity =>
            {
                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.Village)
                    .WithMany(p => p.Wards)
                    .HasForeignKey(d => d.VillageId)
                    .HasConstraintName("FK_dbo.Wards_dbo.Villages_VillageId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

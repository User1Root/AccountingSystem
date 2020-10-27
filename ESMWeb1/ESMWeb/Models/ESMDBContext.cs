using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ESMWeb.Models
{
    public partial class ESMDBContext : DbContext
    {
        public ESMDBContext()
        {
        }

        public ESMDBContext(DbContextOptions<ESMDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Depot> Depot { get; set; }
        public virtual DbSet<Driver> Driver { get; set; }
        public virtual DbSet<Esm> Esm { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Token> Token { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<View1> View1 { get; set; }
        public virtual DbSet<View2> View2 { get; set; }
        public virtual DbSet<View3> View3 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=EsmDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Depot>(entity =>
            {
                entity.ToTable("depot");

                entity.Property(e => e.DepotId)
                    .HasColumnName("depot_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DepotName)
                    .IsRequired()
                    .HasColumnName("depot_name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.ToTable("driver");

                entity.Property(e => e.DriverId)
                    .HasColumnName("driver_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DriverFirstName)
                    .IsRequired()
                    .HasColumnName("driver_firstName")
                    .HasMaxLength(50);

                entity.Property(e => e.DriverSecondName)
                    .IsRequired()
                    .HasColumnName("driver_secondName")
                    .HasMaxLength(50);

                entity.Property(e => e.HomeDepot).HasColumnName("home_depot");

                entity.Property(e => e.HomeEsm).HasColumnName("home_esm");

                entity.HasOne(d => d.HomeDepotNavigation)
                    .WithMany(p => p.Driver)
                    .HasForeignKey(d => d.HomeDepot)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_driver_depot");

                entity.HasOne(d => d.HomeEsmNavigation)
                    .WithMany(p => p.Driver)
                    .HasForeignKey(d => d.HomeEsm)
                    .HasConstraintName("FK_driver_esm");
            });

            modelBuilder.Entity<Esm>(entity =>
            {
                entity.ToTable("esm");

                entity.Property(e => e.EsmId)
                    .HasColumnName("esm_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.HomeDepot).HasColumnName("home_depot");

                entity.Property(e => e.LastDateUsing)
                    .HasColumnName("last_date_using")
                    .HasColumnType("date");

                entity.Property(e => e.LastDepot).HasColumnName("last_depot");

                entity.Property(e => e.LastDriver).HasColumnName("last_driver");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.HomeDepotNavigation)
                    .WithMany(p => p.EsmHomeDepotNavigation)
                    .HasForeignKey(d => d.HomeDepot)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_esm_depot");

                entity.HasOne(d => d.LastDepotNavigation)
                    .WithMany(p => p.EsmLastDepotNavigation)
                    .HasForeignKey(d => d.LastDepot)
                    .HasConstraintName("FK_esm_depot1");

                entity.HasOne(d => d.LastDriverNavigation)
                    .WithMany(p => p.Esm)
                    .HasForeignKey(d => d.LastDriver)
                    .HasConstraintName("FK_esm_driver");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.RoleDesc)
                    .IsRequired()
                    .HasColumnName("role_desc")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Token>(entity =>
            {
                entity.ToTable("token");

                entity.Property(e => e.TokenId).HasColumnName("token_id");

                entity.Property(e => e.ExpireDate)
                    .HasColumnName("expire_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Token1)
                    .IsRequired()
                    .HasColumnName("token")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Token)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_token_user");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.HireDate)
                    .HasColumnName("hire_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("user_name")
                    .HasMaxLength(50);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasColumnName("user_password")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_role");
            });

            modelBuilder.Entity<View1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_1");

                entity.Property(e => e.DepotId)
                    .HasColumnName("depot_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DepotName)
                    .IsRequired()
                    .HasColumnName("depot_name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<View2>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_2");

                entity.Property(e => e.DriverFirstName)
                    .IsRequired()
                    .HasColumnName("driver_firstName")
                    .HasMaxLength(50);

                entity.Property(e => e.DriverId)
                    .HasColumnName("driver_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DriverSecondName)
                    .IsRequired()
                    .HasColumnName("driver_secondName")
                    .HasMaxLength(50);

                entity.Property(e => e.HomeDepot).HasColumnName("home_depot");
            });

            modelBuilder.Entity<View3>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_3");

                entity.Property(e => e.EsmId)
                    .HasColumnName("esm_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.HomeDepot).HasColumnName("home_depot");

                entity.Property(e => e.LastDateUsing)
                    .HasColumnName("last_date_using")
                    .HasColumnType("date");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ModuleAPITest.Models.Package_old
{
    public partial class ModuleAPIContext : DbContext
    {
        public ModuleAPIContext()
        {
        }

        public ModuleAPIContext(DbContextOptions<ModuleAPIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Machine> Machine { get; set; }
        public virtual DbSet<MachineVersion> MachineVersion { get; set; }
        public virtual DbSet<Package> Package { get; set; }
        public virtual DbSet<Version> Version { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Machine>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<MachineVersion>(entity =>
            {
                entity.Property(e => e.CanonicalVersion).HasMaxLength(50);

                entity.Property(e => e.Documentation)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Machine)
                    .WithMany(p => p.MachineVersion)
                    .HasForeignKey(d => d.MachineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MachineVe__Machi__3C69FB99");

                entity.HasOne(d => d.Versions)
                    .WithMany(p => p.MachineVersion)
                    .HasForeignKey(d => d.VersionsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MachineVe__Versi__3D5E1FD2");
            });

            modelBuilder.Entity<Package>(entity =>
            {
                entity.Property(e => e.Categories)
                    .IsRequired()
                    .HasColumnName("categories")
                    .HasMaxLength(255);

                entity.Property(e => e.DefaultVersionName)
                    .IsRequired()
                    .HasColumnName("defaultVersionName")
                    .HasMaxLength(255);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.DisplayName)
                    .HasColumnName("displayName")
                    .HasMaxLength(255);

                entity.Property(e => e.Package1)
                    .IsRequired()
                    .HasColumnName("package")
                    .HasMaxLength(255);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("url")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Version>(entity =>
            {
                entity.Property(e => e.CanonicalVersionString)
                    .IsRequired()
                    .HasColumnName("canonicalVersionString")
                    .HasMaxLength(255);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasColumnName("fullName")
                    .HasMaxLength(255);

                entity.Property(e => e.Help)
                    .HasColumnName("help")
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasColumnName("path")
                    .HasMaxLength(255);

                entity.Property(e => e.VersionName)
                    .IsRequired()
                    .HasColumnName("versionName")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.Version)
                    .HasForeignKey(d => d.PackageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Version__Package__29572725");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

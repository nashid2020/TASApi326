using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ModuleAPITest.Models.Package_old;

namespace ModuleAPITest.Data
{
    public partial class ModuleAPIDBContext : DbContext
    {
        public ModuleAPIDBContext()
        {
            //Database.EnsureCreated();
        }

        public ModuleAPIDBContext(DbContextOptions<ModuleAPIDBContext> options)
            : base(options)
        {
            //ChangeTracker.LazyLoadingEnabled = false;
        }
        public virtual DbSet<MachineIngestModel> Machine { get; set; }
        public virtual DbSet<MachineVersionIngestModel> MachineVersion { get; set; }
        public virtual DbSet<PackageIngestModel1> Package { get; set; }
        public virtual DbSet<VersionIngestModel1> Version { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=DockerConnection");
                //optionsBuilder.UseSqlServer("Name=DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MachineIngestModel>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<MachineVersionIngestModel>(entity =>
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

                entity.HasOne(d => d.Version)
                    .WithMany(p => p.MachineVersion)
                    .HasForeignKey(d => d.VersionsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MachineVe__Versi__3D5E1FD2");
            });

            modelBuilder.Entity<PackageIngestModel1>(entity =>
            {
                entity.Property(e => e.categories)
                    .IsRequired()
                    .HasColumnName("categories")
                    .HasMaxLength(255);

                entity.Property(e => e.defaultVersionName)
                    .IsRequired()
                    .HasColumnName("defaultVersionName")
                    .HasMaxLength(255);

                entity.Property(e => e.description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.displayName)
                    .HasColumnName("displayName")
                    .HasMaxLength(255);

                entity.Property(e => e.package)
                    .IsRequired()
                    .HasColumnName("package")
                    .HasMaxLength(255);

                entity.Property(e => e.url)
                    .IsRequired()
                    .HasColumnName("url")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<VersionIngestModel1>(entity =>
            {
                entity.Property(e => e.canonicalVersionString)
                    .IsRequired()
                    .HasColumnName("canonicalVersionString")
                    .HasMaxLength(255);

                entity.Property(e => e.full)
                    .IsRequired()
                    .HasColumnName("fullName")
                    .HasMaxLength(255);

                entity.Property(e => e.help)
                    .HasColumnName("help")
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.path)
                    .IsRequired()
                    .HasColumnName("path")
                    .HasMaxLength(255);

                entity.Property(e => e.versionName)
                    .IsRequired()
                    .HasColumnName("versionName")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.versions)
                    .HasForeignKey(d => d.PackageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Version__Package__29572725");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

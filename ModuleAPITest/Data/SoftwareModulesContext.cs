using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ModuleAPITest.Models;

namespace ModuleAPITest.Data
{
    public partial class SoftwareModulesContext : DbContext
    {
        public SoftwareModulesContext()
        {
            
        }

        public SoftwareModulesContext(DbContextOptions<SoftwareModulesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Machine> Machine { get; set; }
        public virtual DbSet<MachineVersions> MachineVersions { get; set; }
        public virtual DbSet<MachineVersionsModulePath> MachineVersionsModulePath { get; set; }
        public virtual DbSet<ModulePath> ModulePath { get; set; }
        public virtual DbSet<Package> Package { get; set; }
        public virtual DbSet<Topic> Topic { get; set; }
        public virtual DbSet<Versions> Versions { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseSqlServer("Name=APIConnection");
            //    //optionsBuilder.UseSqlServer("Name=DockerConnection");
            //}
        //}

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

            modelBuilder.Entity<MachineVersions>(entity =>
            {
                entity.Property(e => e.CanonicalVersion).HasMaxLength(50);

                entity.Property(e => e.Documentation)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Machine)
                    .WithMany(p => p.MachineVersions)
                    .HasForeignKey(d => d.MachineId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__MachineVe__Machi__300424B4");

                entity.HasOne(d => d.Versions)
                    .WithMany(p => p.MachineVersions)
                    .HasForeignKey(d => d.VersionsId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__MachineVe__Versi__30F848ED");
            });

            modelBuilder.Entity<MachineVersionsModulePath>(entity =>
            {
                entity.HasOne(d => d.MachineVersions)
                    .WithMany(p => p.MachineVersionsModulePath)
                    .HasForeignKey(d => d.MachineVersionsId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__MachineVe__Machi__35BCFE0A");

                entity.HasOne(d => d.ModulePath)
                    .WithMany(p => p.MachineVersionsModulePath)
                    .HasForeignKey(d => d.ModulePathId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__MachineVe__Modul__36B12243");
            });

            modelBuilder.Entity<ModulePath>(entity =>
            {
                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Package>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.LongName).HasMaxLength(255);

                entity.Property(e => e.ShortName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Url).HasMaxLength(255);

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.Package)
                    .HasForeignKey(d => d.TopicId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Package__TopicId__286302EC");
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<Versions>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.Versions)
                    .HasForeignKey(d => d.PackageId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Versions__Packag__2B3F6F97");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

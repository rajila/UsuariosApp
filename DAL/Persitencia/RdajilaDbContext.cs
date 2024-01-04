using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace DAL.Persitencia
{
	public partial class RdajilaDbContext: DbContext
	{
        public RdajilaDbContext(DbContextOptions<RdajilaDbContext> options) : base(options) { }

        public DbSet<Usuario> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");

                //entity.HasKey(e => e.Id)
                //    .HasName("Usuario_pkey");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.FullName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(true);

                entity.Property(e => e.Estado)
                    .IsUnicode(false)
                    .HasDefaultValue(1);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}


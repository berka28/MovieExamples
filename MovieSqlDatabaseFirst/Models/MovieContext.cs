using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MovieSqlDatabaseFirst.Models
{
    public partial class MovieContext : DbContext
    {
        public MovieContext()
        {
        }

        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Berrkha\\Documents\\MovieSqlDatabaseFirst.mdf;Integrated Security=True;Connect Timeout=30");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(e => e.Ean)
                    .HasName("PK__Movies__C1975A17A2E50DD8");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

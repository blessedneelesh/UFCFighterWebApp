using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Repository.Models.DataLayer
{
    public partial class UFCFightersContext : DbContext
    {
        public UFCFightersContext()
        {
        }

        public UFCFightersContext(DbContextOptions<UFCFightersContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Fighter> Fighters { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fighter>(entity =>
            {
                entity.HasKey(e => e.Fid)
                    .HasName("PK__fighters__D9908D64C6810E2E");

                entity.Property(e => e.Fid).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

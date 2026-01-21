using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DL_SmartAppraisel.Model
{
    public class SmartAppraiselDbContext:DbContext
    {
        public  SmartAppraiselDbContext()
        {

        }
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<DesignationDetail> DesignationDetails { get; set; }
        public DbSet<RoleDetail> RoleDetails { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer("Server=localhost;Database=SmartAppraisel_DB;User Id=sa;Password=password;TrustServerCertificate=True");

            base.OnConfiguring(optionsBuilder);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DesignationDetail>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("GETDATE()");
                entity.Property(e => e.CreatedBy).HasDefaultValue(1);
            });
            base.OnModelCreating(modelBuilder);
        }

    }
}

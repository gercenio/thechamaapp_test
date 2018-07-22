﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TheChamaApp.Domain.Entities;

namespace TheChamaApp.Infra.Data.Contexto
{
    public class TheChamaAppContext : DbContext
    {
        #region # Constructor
        public TheChamaAppContext()
        {
            //this.ChangeTracker.AutoDetectChangesEnabled = false;

        }
        #endregion

        #region # Methods Override
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseMySQL(config.GetSection("ConnectionStrings:Connection").Value);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("InsertAt") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("InsertAt").CurrentValue = DateTime.Now;

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("InsertAt").IsModified = false;
                }
            }

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("UpdateAt") != null))
            {
                if (entry.State == EntityState.Modified)
                    entry.Property("UpdateAt").CurrentValue = DateTime.Now;
            }

            return base.SaveChanges();

            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            
            modelBuilder.Entity<User>().ToTable("user", "hgm");
            modelBuilder.Entity<Company>().ToTable("company", "hgm");
            modelBuilder.Entity<State>().ToTable("state", "hgm");
            modelBuilder.Entity<CompanyContact>().ToTable("companycontact", "hgm");
            modelBuilder.Entity<CompanyAddress>().ToTable("companyaddress", "hgm");
            modelBuilder.Entity<CompanyUnity>().ToTable("companyunity", "hgm");

            base.OnModelCreating(modelBuilder);
        }

        #endregion

        #region # DbSet

        public DbSet<User> User { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<CompanyAddress> CompanyAddress { get; set; }
        public DbSet<CompanyContact> CompanyContact { get; set; }

        #endregion
    }
}
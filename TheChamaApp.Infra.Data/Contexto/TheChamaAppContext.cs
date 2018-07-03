using Microsoft.EntityFrameworkCore;
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
            this.ChangeTracker.AutoDetectChangesEnabled = false;

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

            modelBuilder.Entity<Course>().ToTable("course", "thechamaapp_hmg");
            modelBuilder.Entity<Student>().ToTable("student", "thechamaapp_hmg");
            modelBuilder.Entity<Teacher>().ToTable("teacher", "thechamaapp_hmg");
            modelBuilder.Entity<User>().ToTable("user", "thechamaapp_hmg");
            modelBuilder.Entity<RellationshipCourseTeacher>().ToTable("rellationshipcourseteacher", "thechamaapp_hmg");
            modelBuilder.Entity<RellationshipStudentCourse>().ToTable("rellationshipstudentcourse", "thechamaapp_hmg");

            base.OnModelCreating(modelBuilder);
        }

        #endregion

        #region # DbSet

        public DbSet<RellationshipStudentCourse> RellationshipStudentCourse { get; set; }
        public DbSet<RellationshipCourseTeacher> RellationshipCourseTeacher { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Teacher> Teacher { get; set; }

        #endregion
    }
}
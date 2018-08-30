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
            modelBuilder.Entity<Company>()
                .HasOne(a => a.Address).WithOne(b => b.Company)
                .HasForeignKey<CompanyAddress>(e => e.CompanyId);
            modelBuilder.Entity<Company>().ToTable("company", "hgm")
                .Property(m => m.Name).HasMaxLength(255);
            modelBuilder.Entity<Questions>().ToTable("questions", "hgm");
            modelBuilder.Entity<State>().ToTable("state", "hgm");
            modelBuilder.Entity<CompanyContact>().ToTable("companycontact", "hgm");
            modelBuilder.Entity<CompanyAddress>().ToTable("companyaddress", "hgm")
                .Property(f => f.CompanyAddressId).ValueGeneratedOnAdd();
            modelBuilder.Entity<CompanyUnity>().ToTable("companyunity", "hgm");
            modelBuilder.Entity<Ask>().ToTable("ask", "hgm");
            modelBuilder.Entity<RellationshipQuestionsToAsk>().ToTable("rellationshipquestionstoask", "hgm");
            modelBuilder.Entity<CompanyType>().ToTable("companytype", "hgm");
            modelBuilder.Entity<Answer>().ToTable("answer", "hgm");
            modelBuilder.Entity<RellationshipAskToAnswer>().ToTable("rellationshipasktoanswer", "hgm");
            modelBuilder.Entity<CompanyImage>().ToTable("companyimage", "hgm");
            modelBuilder.Entity<LevelEvaluated>().ToTable("levelevaluated", "hgm");
            modelBuilder.Entity<Login>().ToTable("login", "hgm");
            modelBuilder.Entity<RellationshipCompanyUnityToQuestions>().ToTable("rellationshipcompanyUnitytoquestions", "hgm");
            modelBuilder.Entity<ResultQuestions>().ToTable("resultquestions", "hgm");
            modelBuilder.Entity<Evaluated>().ToTable("evaluated", "hgm");
            modelBuilder.Entity<Quiz>().ToTable("quiz", "hgm");
            modelBuilder.Entity<RellationshipQuizToAsk>().ToTable("rellationshipquiztoask", "hgm");

            base.OnModelCreating(modelBuilder);
        }

        #endregion

        #region # DbSet

        public DbSet<User> User { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<CompanyAddress> CompanyAddress { get; set; }
        public DbSet<CompanyContact> CompanyContact { get; set; }
        public DbSet<CompanyUnity> CompanyUnity { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Ask> Ask { get; set; }
        public DbSet<Answer> Answer { get; set; }
        public DbSet<RellationshipAskToAnswer> RellationshipAskToAnswer { get; set; }
        public DbSet<CompanyImage> CompanyImage { get; set; }
        public DbSet<LevelEvaluated> LevelEvaluated { get; set; }
        public DbSet<Login> Login { get; set; }
        public DbSet<RellationshipCompanyUnityToQuestions> RellationshipCompanyUnityToQuestions { get; set; }
        public DbSet<ResultQuestions> ResultQuestions { get; set; }
        public DbSet<Evaluated> Evaluated { get; set; }
        public DbSet<Quiz> Quiz { get; set; }
        public DbSet<RellationshipQuizToAsk> RellationshipQuizToAsk { get; set; }

        #endregion
    }
}
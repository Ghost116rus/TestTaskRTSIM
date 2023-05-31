using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Aplication.Interfaces;
using TestTask.Domain;
using TestTask.Persistance.EntityTypeConfiguration;

namespace TestTask.Persistance
{
    public class TestTaskDbContext : DbContext, ITestTaskDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Organization> Organizations { get; set; }

        public TestTaskDbContext(DbContextOptions<TestTaskDbContext> options)
            :base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new OrganizationConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.Entity<User>()
                .HasIndex(p => new { p.Login, p.OrganizationId}).IsUnique();


            base.OnModelCreating(modelBuilder);
        }
    }
}

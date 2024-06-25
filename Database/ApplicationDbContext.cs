using Database.Configuration;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Database.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<ContractsUsers> ContractsUsers { get; set; }
        public DbSet<Roles> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ModelConfig(modelBuilder);
        }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new RolesConfiguration(modelBuilder.Entity<Roles>());
            new UsersConfiguration(modelBuilder.Entity<Users>());
            new ContractsUsersConfiguration(modelBuilder.Entity<ContractsUsers>());
        }
    }
}

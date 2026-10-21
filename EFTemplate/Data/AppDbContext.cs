using EFTemplate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFTemplate.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Client> Clients => Set<Client>();
        public DbSet<Car> Cars => Set<Car>();
        public DbSet<ServicePassport> ServicePassports => Set<ServicePassport>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite("Data Source=ef_autoservice.db")
                .LogTo(Console.WriteLine,
                       new[] { DbLoggerCategory.Database.Command.Name },
                       LogLevel.Information);
        }
    }
}
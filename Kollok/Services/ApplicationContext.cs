using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Kollok.Models;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Kollok.Services
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }

        public DbSet<Person> People { get; set; }

        public DbSet<PTask> PTasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=8080;User Id=app;Password=app;Database=mydbname2;");
        }
        /*
        Add-Migration Initial

        Update-Database
        */
    }
}

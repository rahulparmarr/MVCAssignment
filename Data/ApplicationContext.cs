using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MVCAssignment.Data
{
    public class ApplicationContext : DbContext 
    {
        public ApplicationContext()
        {
        }

        public ApplicationContext(DbContextOptions<ApplicationContext>options) : base(options) { }


        public DbSet<User> Users { get; set; }


        public DbSet<EventDetails> Event { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    FullName = "Admin",
                    Email = "myadmin@bookevents.com",
                    Password = "@admin"
                });
        }




    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using portWebApiCore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace portWebApiCore.DAL
{
    
        public class ApplicationDBContext : DbContext
        {
           
           
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./database.db");
        }
        public DbSet<dynamicPort> DynamicPort { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<dynamicPort>().HasData(
            new dynamicPort()
            {
                Id = 1,
                uniqueCode = "Caliber01",
                httpport = 11101,
                httpsport = 22201
            },
            new dynamicPort()
            {
                Id = 2,
                uniqueCode = "Caliber02",
                httpport = 11102,
                httpsport = 22202
            }
            );
        }
        }
}

using LinqPratik.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPratik.LinqDbContext
{
    public class DataContext : DbContext
    {
        public DbSet<Student> Students { get; set; }   
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseInMemoryDatabase(databaseName: "LinqInMemory");
        }
    }
}

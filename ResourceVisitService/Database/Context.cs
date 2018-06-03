using ResourceVisitService.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceVisitService.Database {
    public class Context : DbContext {
        public DbSet<Visit> Visits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(@"Server=ARROZ\SQLEXPRESS;Database=ResourceVisits;Trusted_Connection=True;");
        }
    }
}

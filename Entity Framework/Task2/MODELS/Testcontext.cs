using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITYFRAMEWORK.MODELS
{
    internal class Testcontext:DbContext
    { public virtual DbSet<Catalog> Catalog { get; set; }
        public virtual DbSet<Author> Author { get; set; }
        public virtual DbSet<News> News { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-VPENOVD\\SQLEXPRESS;Database=ITIDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }

    }
}

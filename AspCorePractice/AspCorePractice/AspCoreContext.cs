using AspCorePractice.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCorePractice
{
    public class AspCoreContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AspCoreContext(DbContextOptions<AspCoreContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

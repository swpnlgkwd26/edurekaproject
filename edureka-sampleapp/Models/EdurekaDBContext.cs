using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace edureka_sampleapp.Models
{
    public class EdurekaDBContext:DbContext
    {
        public EdurekaDBContext(DbContextOptions<EdurekaDBContext> options)
            : base(options)
        {
        }
        public DbSet<Account> Accounts { get; set; }
    }
}

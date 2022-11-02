using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence
{
    public class Context : IdentityDbContext<AppUser, AppRole, string>
    {
        public Context(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Customer> Customers { get; set; }
    }
}

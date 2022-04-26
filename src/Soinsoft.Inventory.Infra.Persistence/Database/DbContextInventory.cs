using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Soinsoft.Inventory.Domain.Model;

namespace Soinsoft.Inventory.Infra.Persistence.Database
{
    public class DbContextInventory: DbContext
    {
        public DbContextInventory(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
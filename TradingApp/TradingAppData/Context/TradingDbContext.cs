using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingAppData.Datamodel;

namespace TradingAppData.Context
{
    public class TradingDbContext : DbContext
    {
        public TradingDbContext (DbContextOptions<TradingDbContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customer { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}

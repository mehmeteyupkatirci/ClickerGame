using Clicker.DataAccess.Concrete.EntityFramework.Mappings;
using Clicker.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clicker.DataAccess.Concrete.EntityFramework
{
    public class IdleClickerContext : DbContext
    {
        public IdleClickerContext()
        {
            Database.SetInitializer<IdleClickerContext>(null);
        }

        public DbSet<Improvement> Improvements { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ImprovementMap());
        }
    }
}

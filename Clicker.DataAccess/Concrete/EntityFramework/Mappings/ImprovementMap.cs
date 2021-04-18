using Clicker.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clicker.DataAccess.Concrete.EntityFramework.Mappings
{
    public class ImprovementMap : EntityTypeConfiguration<Improvement>
    {
        public ImprovementMap()
        {
            ToTable(@"improvements");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("improvement_id");
            Property(x => x.CurrentPrice).HasColumnName("current_price");
            Property(x => x.TimeMs).HasColumnName("time_ms");
            Property(x => x.UpgradeCount).HasColumnName("upgrade_count");
            Property(x => x.Manager).HasColumnName("manager");
        }
    }
}

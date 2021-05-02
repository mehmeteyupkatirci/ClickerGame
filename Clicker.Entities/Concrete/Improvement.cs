using Clicker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clicker.Entities.Concrete
{
    public class Improvement : IEntity
    {
        public string Id { get; set; }
        public double CurrentPrice { get; set; }
        public double TimeMs { get; set; }
        public int UpgradeCount { get; set; }
        public bool Manager { get; set; }
        public double DefaultMoney { get; set; }
    }
}

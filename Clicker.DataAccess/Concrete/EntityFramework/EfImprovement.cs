using Clicker.Core.DataAccess.EntityFramework;
using Clicker.DataAccess.Abstract;
using Clicker.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clicker.DataAccess.Concrete.EntityFramework
{
    public class EfImprovement: EfEntityRepositoryBase<Improvement, IdleClickerContext> , IImprovementDal
    {
    }
}

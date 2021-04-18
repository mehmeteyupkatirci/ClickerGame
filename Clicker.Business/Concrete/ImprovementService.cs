using Clicker.Business.Abstract;
using Clicker.DataAccess.Concrete.EntityFramework;
using Clicker.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clicker.Business.Concrete
{
    public class ImprovementService : IImprovementService
    {
        EfImprovement _improvement = new EfImprovement();

        public bool AddImprovement(Improvement improvement)
        {
            var result = _improvement.Add(improvement);
            if (result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DeleteImprovement(Improvement improvement)
        {
            _improvement.Delete(improvement);
        }

        public Improvement GetImprovement(string improvementId)
        {
            return _improvement.Get(x => x.Id == improvementId);
        }

        public List<Improvement> ImprovementList()
        {
            return _improvement.GetList();
        }

        public bool UpdateImprovement(Improvement improvement)
        {
            var result = _improvement.Update(improvement);
            if (result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

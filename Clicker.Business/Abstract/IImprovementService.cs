using Clicker.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clicker.Business.Abstract
{
    public interface IImprovementService
    {
        bool InitImprovements();
        List<Improvement> ImprovementList();
        Improvement GetImprovement(string improvementId);
        bool UpdateImprovement(Improvement improvement);
        void DeleteImprovement(Improvement improvement);
        bool AddImprovement(Improvement improvement);
    }
}

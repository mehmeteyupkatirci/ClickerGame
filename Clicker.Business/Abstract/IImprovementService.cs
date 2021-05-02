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
        List<ConfigurationData> ImprovementList();
        ConfigurationData GetImprovement(string improvementId);
        bool UpdateImprovement(ConfigurationData improvement);
        void DeleteImprovement(ConfigurationData improvement);
        bool AddImprovement(ConfigurationData improvement);
    }
}

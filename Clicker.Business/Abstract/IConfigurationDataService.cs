using Clicker.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clicker.Business.Abstract
{
    public interface IConfigurationDataService
    {
        bool InitConfigurationData();
        List<ConfigurationData> ConfigurationDataList();
        ConfigurationData GetConfigurationData(string improvementId);
        bool UpdateConfigurationData(ConfigurationData improvement);
        void DeleteConfigurationData(ConfigurationData improvement);
        bool AddConfigurationData(ConfigurationData improvement);
    }
}

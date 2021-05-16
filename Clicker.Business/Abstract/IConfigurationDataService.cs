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
        bool InitImprovementsData();
        bool DeleteImprovementsData();
        List<ConfigurationData> ConfigurationDataList();
        ConfigurationData GetConfigurationData(string key);
        bool UpdateConfigurationData(string key, string value);
        void DeleteConfigurationData(string key);
        bool AddConfigurationData(string key, string value);
    }
}

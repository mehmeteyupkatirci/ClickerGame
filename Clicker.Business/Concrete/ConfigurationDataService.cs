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
    public class ConfigurationDataService : IConfigurationDataService
    {
        EfConfigurationDataDal _configurationDataDal = new EfConfigurationDataDal();

        public bool AddConfigurationData(string key, string value)
        {
            var result = _configurationDataDal.Add(new ConfigurationData { Key = key, Value = value });
            if (result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<ConfigurationData> ConfigurationDataList()
        {
            return _configurationDataDal.GetList();
        }

        public void DeleteConfigurationData(string key)
        {
            _configurationDataDal.Delete(_configurationDataDal.Get(x => x.Key == key));
        }

        public ConfigurationData GetConfigurationData(string key)
        {
            return _configurationDataDal.Get(x => x.Key == key);
        }

        ///<summary>
        ///Oyun ilk defa yükleniyorsa database'de bulunması gereken kayıtlar ve configuration bilgilerini oluşturmak için program çalıştırıldıktan sonra 1 kez çağırılır.
        ///</summary>
        public bool InitImprovementsData()
        {
            var isFirstOpen = _configurationDataDal.Get(x => x.Key == "firstLoad");
            if (isFirstOpen == null)
            {
                _configurationDataDal.Add(new ConfigurationData { Key = "firstLoad", Value = "done" });
                _configurationDataDal.Add(new ConfigurationData { Key = "money", Value = "0" });
                return true;
            }
            else if (isFirstOpen.Value == "deleted")
            {
                _configurationDataDal.Update(new ConfigurationData { Key = "firstLoad", Value = "done" });
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteImprovementsData()
        {
            var isFirstOpen = _configurationDataDal.Get(x => x.Key == "firstLoad");
            if (isFirstOpen == null)
            {
                _configurationDataDal.Update(new ConfigurationData { Key = "firstLoad", Value = "deleted" });
                _configurationDataDal.Update(new ConfigurationData { Key = "money", Value = "0" });
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateConfigurationData(string key, string value)
        {
            var configItem = _configurationDataDal.Get(x => x.Key == key);
            configItem.Value = value;
            var result = _configurationDataDal.Update(configItem);
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

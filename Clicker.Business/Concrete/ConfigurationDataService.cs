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

        public bool AddConfigurationData(ConfigurationData improvement)
        {
            throw new NotImplementedException();
        }

        public List<ConfigurationData> ConfigurationDataList()
        {
            throw new NotImplementedException();
        }

        public void DeleteConfigurationData(ConfigurationData improvement)
        {
            throw new NotImplementedException();
        }

        public ConfigurationData GetConfigurationData(string improvementId)
        {
            throw new NotImplementedException();
        }

        ///<summary>
        ///Oyun ilk defa yükleniyorsa database'de bulunması gereken kayıtlar ve configuration bilgilerini oluşturmak için program çalıştırıldıktan sonra 1 kez çağırılır.
        ///</summary>
        public bool InitConfigurationData()
        {
            var isFirstOpen = _configurationDataDal.Get(x => x.Key == "firstLoad");
            if (isFirstOpen == null)
            {
                isFirstOpen = new ConfigurationData { Key = "firstLoad", Value = "done" };
                _configurationDataDal.Add(isFirstOpen);
                var money = new ConfigurationData { Key = "money", Value = "0" };
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateConfigurationData(ConfigurationData improvement)
        {
            throw new NotImplementedException();
        }
    }
}

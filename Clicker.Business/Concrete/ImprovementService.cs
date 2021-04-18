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
        EfImprovementDal _improvementDal = new EfImprovementDal();
        EfConfigurationDataDal  _configurationDataDal = new EfConfigurationDataDal();

        ///<summary>
        ///Database yeni bir Improvement ekler.
        ///</summary>
        public bool AddImprovement(Improvement improvement)
        {
            var result = _improvementDal.Add(improvement);
            if (result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        ///<summary>
        ///Database'den ilgili Improvement bilgilerini siler.
        ///</summary>
        public void DeleteImprovement(Improvement improvement)
        {
            _improvementDal.Delete(improvement);
        }

        ///<summary>
        ///Database'den ilgili Improvement bilgilerini getirir.
        ///</summary>
        public Improvement GetImprovement(string improvementId)
        {
            return _improvementDal.Get(x => x.Id == improvementId);
        }

        ///<summary>
        ///Database'de bulunan tüm Improvement bilgilerini getirir.
        ///</summary>
        public List<Improvement> ImprovementList()
        {
            return _improvementDal.GetList();
        }

        ///<summary>
        ///Oyun ilk defa yükleniyorsa database'de bulunması gereken kayıtlar ve configuration bilgilerini oluşturmak için program çalıştırıldıktan sonra 1 kez çağırılır.
        ///</summary>
        public bool InitConfiguration()
        {
            var isFirstOpen = _configurationDataDal.Get(x => x.Key == "firstLoad");
            if (isFirstOpen == null)
            {
                isFirstOpen = new ConfigurationData { Key = "firstLoad", Value = "done" };
                _configurationDataDal.Add(isFirstOpen);
                return true;
            }
            else
            {
                return false;
            }           
        }

        ///<summary>
        ///Database'de bulunan ilgili Improvement'ın bilgilerini günceller.
        ///</summary>
        public bool UpdateImprovement(Improvement improvement)
        {
            var result = _improvementDal.Update(improvement);
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

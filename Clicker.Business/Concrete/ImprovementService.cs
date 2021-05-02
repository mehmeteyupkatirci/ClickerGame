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

        ///<summary>
        ///Database yeni bir Improvement ekler.
        ///</summary>
        public bool AddImprovement(ConfigurationData improvement)
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
        public void DeleteImprovement(ConfigurationData improvement)
        {
            _improvementDal.Delete(improvement);
        }

        ///<summary>
        ///Database'den ilgili Improvement bilgilerini getirir.
        ///</summary>
        public ConfigurationData GetImprovement(string improvementId)
        {
            return _improvementDal.Get(x => x.Id == improvementId);
        }

        ///<summary>
        ///Database'de bulunan tüm Improvement bilgilerini getirir.
        ///</summary>
        public List<ConfigurationData> ImprovementList()
        {
            return _improvementDal.GetList();
        }

        public bool InitImprovements()
        {
            throw new NotImplementedException();
        }

        ///<summary>
        ///Database'de bulunan ilgili Improvement'ın bilgilerini günceller.
        ///</summary>
        public bool UpdateImprovement(ConfigurationData improvement)
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

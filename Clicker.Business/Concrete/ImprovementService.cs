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
        ///Database'deki bütün Improvement bilgilerini siler.
        ///</summary>
        public bool DeleteAllImprovement()
        {
            try
            {
                var deletelist = ImprovementList(); 
                deletelist.ForEach(x => _improvementDal.Delete(x));
                return true;
            }
            catch (Exception)
            {
                return false;                
            }         
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
        ///Oyun ilk defa çalıştığında database'e ilgili sütünları ekler. (InitConfiguration true geldiğinde çağırılır)
        ///</summary>
        public bool InitImprovements()
        {
            try
            {
                _improvementDal.Add(new Improvement() { Id = "one", CurrentPrice = 10, DefaultMoney = 1, Manager = true, TimeMs = 2, UpgradeCount = 1 });
                _improvementDal.Add(new Improvement() { Id = "two", CurrentPrice = 50, DefaultMoney = 5, Manager = false, TimeMs = 4, UpgradeCount = 0 });
                _improvementDal.Add(new Improvement() { Id = "three", CurrentPrice = 1000, DefaultMoney = 30, Manager = false, TimeMs = 6, UpgradeCount = 0 });
                _improvementDal.Add(new Improvement() { Id = "four", CurrentPrice = 5000, DefaultMoney = 100, Manager = false, TimeMs = 8, UpgradeCount = 0 });
                _improvementDal.Add(new Improvement() { Id = "five", CurrentPrice = 30000, DefaultMoney = 1000, Manager = false, TimeMs = 10, UpgradeCount = 0 });
                _improvementDal.Add(new Improvement() { Id = "six", CurrentPrice = 100000, DefaultMoney = 5000, Manager = false, TimeMs = 12, UpgradeCount = 0 });
                _improvementDal.Add(new Improvement() { Id = "seven", CurrentPrice = 1000000, DefaultMoney = 50000, Manager = false, TimeMs = 14, UpgradeCount = 0 });
                _improvementDal.Add(new Improvement() { Id = "eight", CurrentPrice = 10000000, DefaultMoney = 1000000, Manager = false, TimeMs = 16, UpgradeCount = 0 });
                _improvementDal.Add(new Improvement() { Id = "nine", CurrentPrice = 50000000, DefaultMoney = 10000000, Manager = false, TimeMs = 18, UpgradeCount = 0 });
                _improvementDal.Add(new Improvement() { Id = "ten", CurrentPrice = 250000000, DefaultMoney = 100000000, Manager = false, TimeMs = 20, UpgradeCount = 0 });
                return true;
            }
            catch (Exception)
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

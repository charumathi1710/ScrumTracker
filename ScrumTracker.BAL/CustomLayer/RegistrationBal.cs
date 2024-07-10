using ScrumTracker.BAL.ICustomLayer;
using ScrumTracker.DAL.IDataAccessLayer;
using ScrumTracker.DataObject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTracker.BAL.CustomLayer
{
    public class RegistrationBal:IRegistrationBal
    {
        private IUnitofData UnitofData { get; }
        public RegistrationBal(IUnitofData unitofData)
        {
            UnitofData = unitofData;
        }
        public Task<UserTokenEntity> AddUserAsync(UserTokenEntity user)
        {
            return UnitofData.RegistrationDal.AddUserAsync(user);
        }
        public Task<UserTokenEntity> GetUserByIdAsync(int id)
        {
            return UnitofData.RegistrationDal.GetUserByIdAsync(id);
        }
    }
}

using ScrumTracker.BAL.ICustomLayer;
using ScrumTracker.DAL.IDataAccessLayer;
using ScrumTracker.DataObject.ResponseEntity;
using ScrumTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTracker.BAL.CustomLayer
{
    public class UserServiceBal:IUserServiceBal
    {
        private IUnitofData UnitofData { get; }
        public UserServiceBal(IUnitofData unitofData)
        {
            UnitofData = unitofData;
        }
        public async Task<List<UserMasterViewEntity>> GetByDepartment(string department)
        {
            return await UnitofData.UserServiceDal.GetByDepartment(department);
        }
    }
}

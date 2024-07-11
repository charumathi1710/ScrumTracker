using ScrumTracker.BAL.ICustomLayer;
using ScrumTracker.DAL.IDataAccessLayer;
using ScrumTracker.DataObject.Entity;
using ScrumTracker.DataObject.ResponseEntity;
using ScrumTracker.DataObject.ViewEntity;
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

        public async Task<ResponseEntity<List<UserStatusEntity>>> GetAllUserStatus()
        {
           return await UnitofData.UserServiceDal.GetAllUserStatus();
        }
        public async Task<ResponseEntity<List<UserStatusViewEntity>>> GetByDepartment(string department)
        {
            return await UnitofData.UserServiceDal.GetByDepartment(department);
        }

    }
}

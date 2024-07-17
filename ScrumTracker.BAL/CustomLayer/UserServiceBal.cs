using ScrumTracker.BAL.ICustomLayer;
using ScrumTracker.DAL.DataAccessLayer;
using ScrumTracker.DAL.IDataAccessLayer;
using ScrumTracker.DataObject.Entity;
using ScrumTracker.DataObject.RequestEntity;
using ScrumTracker.DataObject.ResponseEntity;
using ScrumTracker.DataObject.ViewEntity;
using ScrumTracker.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace ScrumTracker.BAL.CustomLayer
{
    public class UserServiceBal:IUserServiceBal
    {
        private IUnitofData UnitofData { get; }
        public UserServiceBal(IUnitofData unitofData)
        {
            UnitofData = unitofData;
        }
        #region DailyScrum
        public async Task<ResponseEntity<List<EmpScrumStatusEntity>>> GetAllUserStatus()
        {
            return await UnitofData.UserServiceDal.GetAllUserStatus();
        }
        public async Task<ResponseEntity<List<EmpStatusViewEntity>>> GetByDepartment(string department)
        {
            return await UnitofData.UserServiceDal.GetByDepartment(department);
        }

        public async Task<ResponseEntity<IEnumerable<EmpWorkTypeEntity>>> GetAllWorkType()
        {
            return await UnitofData.UserServiceDal.GetAllWorkType();
        }

        public async Task<ResponseEntity<int>> PostScrumStatusData(EmpStatusResponseEntity updatestatus)
        { 
            return await UnitofData.UserServiceDal.PostScrumStatusData(updatestatus);
        }
        #endregion
        #region TaskOverview
        public async Task<ResponseEntity<List<EmpSearchStatusViewEntity>>> SearchEmpScrumStatus(string searchTerm)
        {
            return await UnitofData.UserServiceDal.SearchEmpScrumStatus(searchTerm);
        }
        #endregion
    }
}

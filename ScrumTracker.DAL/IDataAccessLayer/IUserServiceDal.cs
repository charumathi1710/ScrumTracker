using ScrumTracker.DataObject.Entity;
using ScrumTracker.DataObject.RequestEntity;
using ScrumTracker.DataObject.ResponseEntity;
using ScrumTracker.DataObject.ViewEntity;
using ScrumTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTracker.DAL.IDataAccessLayer
{
    public interface IUserServiceDal
    {
        #region DailyScrum
        Task<ResponseEntity<List<EmpStatusViewEntity>>> GetByDepartment(string department);
        Task<ResponseEntity<List<EmpScrumStatusEntity>>> GetAllUserStatus();
        Task<ResponseEntity<IEnumerable<EmpWorkTypeEntity>>> GetAllWorkType();
        Task<ResponseEntity<int>> PostScrumStatusData(EmpStatusResponseEntity updatestatus);
        #endregion
        #region TaskOverview
        Task<ResponseEntity<List<EmpSearchStatusViewEntity>>> SearchEmpScrumStatus(string searchTerm);
        #endregion
    }
}


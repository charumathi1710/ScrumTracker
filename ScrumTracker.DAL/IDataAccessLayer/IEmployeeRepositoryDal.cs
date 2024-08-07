using ScrumTracker.DataObject.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTracker.DAL.IDataAccessLayer
{
    public interface IEmployeeRepositoryDal
    {
        Task<List<EmployeeScrumReport>> GetEmployeeScrumReportAsync();
    }
}

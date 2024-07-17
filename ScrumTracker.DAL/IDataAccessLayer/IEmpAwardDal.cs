using ScrumTracker.DataObject.Entity;
using ScrumTracker.DataObject.ResponseEntity;
using ScrumTracker.DataObject.ViewEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTracker.DAL.IDataAccessLayer
{
    public interface IEmpAwardDal
    {
        Task<ResponseEntity<List<EmpAwardResponseEntity>>> GetByUserAwardByMonthAndYear(string month, int year);
        Task<ResponseEntity<EmpAwardResponseEntity>> SendDataToUserAward(EmpAwardEntity model);
        Task<ResponseEntity<bool>> RemoveDataFromUserAward(int Id);
    }
}

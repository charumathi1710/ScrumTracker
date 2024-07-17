using ScrumTracker.DataObject.RequestEntity;
using ScrumTracker.DataObject.ResponseEntity;
using ScrumTracker.DataObject.ViewEntity;

namespace ScrumTracker.BAL.ICustomLayer
{
    public interface IEmpAwardBal
    {
        Task<ResponseEntity<List<EmpAwardResponseEntity>>> GetByUserAwardByMonthAndYear(string month, int year);
        Task<ResponseEntity<EmpAwardResponseEntity>> SendDataToUserAward(EmpAwardRequestEntity uaModel);
        Task<ResponseEntity<bool>> RemoveDataFromUserAward(int userAwardId);
    }
}

using ScrumTracker.BAL.ICustomLayer;
using ScrumTracker.DAL.IDataAccessLayer;
using ScrumTracker.DataObject.Entity;
using ScrumTracker.DataObject.RequestEntity;
using ScrumTracker.DataObject.ResponseEntity;
using ScrumTracker.DataObject.ViewEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTracker.BAL.CustomLayer
{
    public class EmpAwardBal:IEmpAwardBal
    {
        private IUnitofData UnitOfData { get; }

        public EmpAwardBal(IUnitofData unitOfData)
        {
            UnitOfData = unitOfData;
        }
        public async Task<ResponseEntity<List<EmpAwardResponseEntity>>> GetByUserAwardByMonthAndYear(string month, int year)
        {
            return await UnitOfData.UserAwardDal.GetByUserAwardByMonthAndYear(month, year);
        }
        public async Task<ResponseEntity<EmpAwardResponseEntity>> SendDataToUserAward(EmpAwardRequestEntity uaModel)
        {
            var model = new EmpAwardEntity()
            {
                EmpAwardID = uaModel.EmpAwardID,
                EmpDetailId = uaModel.EmpDetailID,
                Month = uaModel.Month,
                Year = uaModel.Year,
                CreationDate = DateTime.Now,
                HostName = System.Net.Dns.GetHostName().ToString(),
                UpdatedAt = DateTime.Now,
            };

            return await UnitOfData.UserAwardDal.SendDataToUserAward(model);
        }
        public async Task<ResponseEntity<bool>> RemoveDataFromUserAward(int userAwardId)
        {
            return await UnitOfData.UserAwardDal.RemoveDataFromUserAward(userAwardId);
        }
    }
}

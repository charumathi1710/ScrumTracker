using ScrumTracker.BAL.ICustomLayer;
using ScrumTracker.DAL.IDataAccessLayer;
using ScrumTracker.DataObject.Entity;
using ScrumTracker.DataObject.ResponseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTracker.BAL.CustomLayer
{
    public class EmpServiceBal:IEmpServiceBal
    {
        private IUnitofData UnitofData { get; }
        public EmpServiceBal(IUnitofData unitofData)
        {
            UnitofData = unitofData;
        }

        public async Task<ResponseEntity<List<EmpDetailsEntity>>> GetAllEmpDetails()
        {
           return await UnitofData.EmpServiceDal.GetAllEmpDetails();
        }

        public async Task<ResponseEntity<int>> PostData(EmpDetailsResponseEntity postandupdate)
        {
           return await UnitofData.EmpServiceDal.PostEmployeeData(postandupdate);
        }

        public async Task<ResponseEntity<List<EmpDetailsEntity>>> DeleteData(int id)
        {
            return await UnitofData.EmpServiceDal.DeleteEmployeeData(id);
        }
        public async Task<ResponseEntity<List<EmpDetailsEntity>>> GetEmpDetailById(int id)
        {
           return await UnitofData.EmpServiceDal.GetEmpDetailById(id);
        }
    }
}

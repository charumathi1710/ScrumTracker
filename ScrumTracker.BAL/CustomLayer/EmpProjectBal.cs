using ScrumTracker.BAL.ICustomLayer;
using ScrumTracker.DAL.DataAccessLayer;
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
    public class EmpProjectBal:IEmpProjectBal
    {
        private IUnitofData UnitOfData { get; }

        public EmpProjectBal(IUnitofData unitOfData)
        {
            UnitOfData = unitOfData;
        }
        public async Task<ResponseEntity<List<EmpProjectResponseEntity>>> GetAllProject()
        {
            return await UnitOfData.EmpProjectDal.GetAllProject();
        }
        public async Task<ResponseEntity<int>> PostProject(EmpProjectEntity updateProject)
        {
            return await UnitOfData.EmpProjectDal.PostProject(updateProject);
        }
    }
}

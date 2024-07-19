using ScrumTracker.DataObject.Entity;
using ScrumTracker.DataObject.ResponseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTracker.DAL.IDataAccessLayer
{
    public interface IEmpProjectDal
    {
        Task<ResponseEntity<List<EmpProjectResponseEntity>>> GetAllProject();
        Task<ResponseEntity<int>> PostProject(EmpProjectEntity empProject);
    }
}

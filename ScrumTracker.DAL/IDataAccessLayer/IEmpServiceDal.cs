using ScrumTracker.DataObject.Entity;
using ScrumTracker.DataObject.ResponseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTracker.DAL.IDataAccessLayer
{
    public interface IEmpServiceDal
    {
        Task<ResponseEntity<List<EmpDetailsEntity>>> GetAllEmpDetails();
        Task<ResponseEntity<List<EmpDetailsEntity>>> GetEmpDetailById(int id);
        Task<ResponseEntity<int>> PostEmployeeData(EmpDetailsResponseEntity postEmp);
        Task<ResponseEntity<List<EmpDetailsEntity>>> DeleteEmployeeData(int id);

    }
}

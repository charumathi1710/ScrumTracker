using ScrumTracker.DataObject.Entity;
using ScrumTracker.DataObject.ResponseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTracker.BAL.ICustomLayer
{
    public interface IEmpServiceBal
    {
        Task<ResponseEntity<List<EmpDetailsEntity>>> GetAllEmpDetails();
        Task<ResponseEntity<List<EmpDetailsEntity>>> GetEmpDetailById(int id);
        Task<ResponseEntity<int>> PostData(EmpDetailsResponseEntity postandupdate);
        Task<ResponseEntity<List<EmpDetailsEntity>>> DeleteData(int id);    
    }
}

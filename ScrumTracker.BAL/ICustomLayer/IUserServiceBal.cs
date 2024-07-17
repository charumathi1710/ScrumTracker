using ScrumTracker.DataObject.Entity;
using ScrumTracker.DataObject.ResponseEntity;
using ScrumTracker.DataObject.ViewEntity;
using ScrumTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTracker.BAL.ICustomLayer
{
    public interface IUserServiceBal
    {
        Task<ResponseEntity<List<UserStatusViewEntity>>> GetByDepartment(string department);
        Task<ResponseEntity<List<EmpDetailEntity>>> GetAllUserStatus();
    }
}

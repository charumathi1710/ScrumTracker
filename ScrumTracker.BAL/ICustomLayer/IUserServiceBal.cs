using ScrumTracker.DataObject.ResponseEntity;
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
        Task<List<UserMasterViewEntity>> GetByDepartment(string department);
    }
}

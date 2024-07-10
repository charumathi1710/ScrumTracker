using ScrumTracker.DataObject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTracker.BAL.ICustomLayer
{
    public interface IRegistrationBal
    {
        Task<UserTokenEntity> AddUserAsync(UserTokenEntity user);
        Task<UserTokenEntity> GetUserByIdAsync(int id);
    }
}

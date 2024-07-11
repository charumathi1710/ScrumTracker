using ScrumTracker.DataObject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTracker.DAL.IDataAccessLayer
{
    public interface IRegistrationDal
    {
        Task<UserTokenEntity> AddUserAsync(UserTokenEntity user);
        Task<UserTokenEntity> GetUserByIdAsync(int id);
    }
}

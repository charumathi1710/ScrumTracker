using ScrumTracker.DataObject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTracker.BAL.ICustomLayer
{
    public interface IAuthenticationBal
    {
        UserTokenEntity GetUserByUsernameAndPassword(string username, string password,string department);
        UserTokenEntity GetUserByRefreshToken(string refreshToken);
        void UpdateUser(UserTokenEntity user);
    }
}

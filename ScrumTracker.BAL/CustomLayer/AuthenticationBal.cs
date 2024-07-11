using ScrumTracker.BAL.ICustomLayer;
using ScrumTracker.DAL.DataAccessLayer;
using ScrumTracker.DAL.IDataAccessLayer;
using ScrumTracker.DataObject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTracker.BAL.CustomLayer
{
    public class AuthenticationBal:IAuthenticationBal
    {
        private IUnitofData UnitofData { get; }
        public AuthenticationBal(IUnitofData unitofData)
        {
            UnitofData = unitofData;
        }
        public UserTokenEntity GetUserByUsernameAndPassword(string username, string password, string rolename)
        {
            return UnitofData.AuthenticationDal.GetUserByUsernameAndPassword(username, password, rolename);
        }
        public UserTokenEntity GetUserByRefreshToken(string refreshToken)
        {
            return UnitofData.AuthenticationDal.GetUserByRefreshToken(refreshToken);
        }
        public void UpdateUser(UserTokenEntity user)
        {
             UnitofData.AuthenticationDal.UpdateUser(user);
        }
    }
}

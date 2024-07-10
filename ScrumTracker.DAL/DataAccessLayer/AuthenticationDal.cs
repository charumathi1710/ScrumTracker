using Microsoft.EntityFrameworkCore;
using ScrumTracker.DAL.IDataAccessLayer;
using ScrumTracker.DataObject.Context;
using ScrumTracker.DataObject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTracker.DAL.DataAccessLayer
{
    public class AuthenticationDal:IAuthenticationDal
    {
        private readonly ApplicationDBContext _context;
        public AuthenticationDal(ApplicationDBContext context)
        {
            _context = context;
        }
        public UserTokenEntity GetUserByUsernameAndPassword(string username, string password, string rolename)
        {
            var roleExists = _context.Roles.Any(r => r.RoleName == rolename);
            if (!roleExists)
            {
                return null; 
            }

            var userWithRole = _context.UserToken
                .Join(_context.Roles,
                     userToken => userToken.RoleID,
                     role => role.RoleID,
                     (userToken, role) => new { userToken, role })
                .Where(x => x.userToken.Username == username && x.userToken.Password == password && x.role.RoleName == rolename)
                .Select(x => x.userToken)
                .SingleOrDefault();

            return userWithRole ?? null;
        }

        public UserTokenEntity GetUserByRefreshToken(string refreshToken)
        {
            return _context.UserToken.SingleOrDefault(u => u.RefreshToken == refreshToken);
        }

        public void UpdateUser(UserTokenEntity user)
        {
            _context.UserToken.Update(user);
            _context.SaveChanges();
        }
    }
}

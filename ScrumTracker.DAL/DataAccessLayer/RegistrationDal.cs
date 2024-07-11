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
    public class RegistrationDal:IRegistrationDal
    {
        private readonly ApplicationDBContext _context;

        public RegistrationDal(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<UserTokenEntity> AddUserAsync(UserTokenEntity user)
        {
            _context.UserToken.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<UserTokenEntity> GetUserByIdAsync(int id)
        {
            return await _context.UserToken.FindAsync(id);
        }
    }
}

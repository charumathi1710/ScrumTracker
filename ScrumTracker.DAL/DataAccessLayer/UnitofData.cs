using ScrumTracker.DAL.IDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTracker.DAL.DataAccessLayer
{
    public class UnitofData:IUnitofData
    {
        public UnitofData(IUserServiceDal userService)
        {
            UserServiceDal= userService;
        }
        public IUserServiceDal UserServiceDal { get; }
    }
}

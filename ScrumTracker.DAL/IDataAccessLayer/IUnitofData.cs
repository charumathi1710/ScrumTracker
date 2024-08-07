using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTracker.DAL.IDataAccessLayer
{
    public interface IUnitofData
    {
        public IUserServiceDal UserServiceDal { get; }
        public IAuthenticationDal AuthenticationDal { get; }
        public IRefreshTokenDal RefreshTokenDal { get; }
        public IRegistrationDal RegistrationDal { get; }
        public IEmpAwardDal UserAwardDal { get; }
        public IEmpServiceDal EmpServiceDal { get; }
        public IQuotesDal QuotesDal { get; }
        public IEmpProjectDal EmpProjectDal { get; }
        public IEmployeeRepositoryDal EmployeeRepositoryDal { get; }
    }
}

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
        public UnitofData(IUserServiceDal userService, IAuthenticationDal authenticationDal,
            IRefreshTokenDal refreshTokenDal, IRegistrationDal registrationDal,
            IEmpAwardDal userAwardDal,IQuotesDal quotesDal)        
        {
            UserServiceDal = userService;
            AuthenticationDal = authenticationDal;
            RefreshTokenDal = refreshTokenDal;
            RegistrationDal = registrationDal;
            UserAwardDal= userAwardDal;
            QuotesDal= quotesDal;
        }
        public IUserServiceDal UserServiceDal { get; }
        public IAuthenticationDal AuthenticationDal { get; }
        public IRefreshTokenDal RefreshTokenDal { get; }
        public IRegistrationDal RegistrationDal { get; }
        public IEmpAwardDal UserAwardDal { get; }
        public IQuotesDal QuotesDal { get; }
    }
}

using ScrumTracker.BAL.ICustomLayer;

namespace ScrumTracker.BAL.CustomLayer
{
    public class UnitofWork:IUnitofWork
    {
        public UnitofWork(IUserServiceBal userService, IAuthenticationBal authenticationBal,
            IRefreshTokenBal refreshTokenBal, IRegistrationBal registrationBal,
            IEmpAwardBal userAwardBal,IQuotesBal quotesBal,
            IEmpProjectBal empProjectBal)
        {
            UserServiceBal = userService;
            AuthenticationBal = authenticationBal;
            RefreshTokenBal = refreshTokenBal;
            RegistrationBal = registrationBal;
            UserAwardBal = userAwardBal;
            QuotesBal = quotesBal;
            EmpProjectBal = empProjectBal;
        }
        public IUserServiceBal UserServiceBal { get; }
        public IAuthenticationBal AuthenticationBal { get; }
        public IRefreshTokenBal RefreshTokenBal { get; }
        public IRegistrationBal RegistrationBal { get; }
        public IEmpAwardBal UserAwardBal { get; }
        public IQuotesBal QuotesBal { get; }
        public IEmpProjectBal EmpProjectBal { get; }
    }
}

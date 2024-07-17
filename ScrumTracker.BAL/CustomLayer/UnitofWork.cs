using ScrumTracker.BAL.ICustomLayer;

namespace ScrumTracker.BAL.CustomLayer
{
    public class UnitofWork:IUnitofWork
    {
        public UnitofWork(IUserServiceBal userService, IAuthenticationBal authenticationBal,
            IRefreshTokenBal refreshTokenBal, IRegistrationBal registrationBal,
            IEmpAwardBal userAwardBal)
        {
            UserServiceBal = userService;
            AuthenticationBal = authenticationBal;
            RefreshTokenBal = refreshTokenBal;
            RegistrationBal = registrationBal;
            UserAwardBal = userAwardBal;
        }
        public IUserServiceBal UserServiceBal { get; }
        public IAuthenticationBal AuthenticationBal { get; }
        public IRefreshTokenBal RefreshTokenBal { get; }
        public IRegistrationBal RegistrationBal { get; }
        public IEmpAwardBal UserAwardBal { get; }
    }
}

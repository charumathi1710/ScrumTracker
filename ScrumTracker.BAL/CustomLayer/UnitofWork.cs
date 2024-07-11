using ScrumTracker.BAL.ICustomLayer;

namespace ScrumTracker.BAL.CustomLayer
{
    public class UnitofWork:IUnitofWork
    {
        public UnitofWork(IUserServiceBal userService, IAuthenticationBal authenticationBal,
            IRefreshTokenBal refreshTokenBal, IRegistrationBal registrationBal)
        {
            UserServiceBal = userService;
            AuthenticationBal = authenticationBal;
            RefreshTokenBal = refreshTokenBal;
            RegistrationBal = registrationBal;
        }
        public IUserServiceBal UserServiceBal { get; }
        public IAuthenticationBal AuthenticationBal { get; }
        public IRefreshTokenBal RefreshTokenBal { get; }
        public IRegistrationBal RegistrationBal { get; }
    }
}

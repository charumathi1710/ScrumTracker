using ScrumTracker.BAL.ICustomLayer;
using ScrumTracker.DAL.IDataAccessLayer;

namespace ScrumTracker.BAL.CustomLayer
{
    public class UnitofWork:IUnitofWork
    {
        public UnitofWork(IUserServiceBal userService, IAuthenticationBal authenticationBal,
            IRefreshTokenBal refreshTokenBal, IRegistrationBal registrationBal,
            IEmpAwardBal userAwardBal,IQuotesBal quotesBal,
            IEmpProjectBal empProjectBal,IEmpServiceBal empServiceBal,
            IEmployeeMailServiceBal employeeMailServiceBal,IEmailService emailService)
        {
            UserServiceBal = userService;
            AuthenticationBal = authenticationBal;
            RefreshTokenBal = refreshTokenBal;
            RegistrationBal = registrationBal;
            UserAwardBal = userAwardBal;         
            EmpProjectBal = empProjectBal;
            EmpServiceBal=empServiceBal;
            QuotesBal=quotesBal;
            EmployeeMailServiceBal = employeeMailServiceBal;
            EmailService = emailService;
        }
        public IUserServiceBal UserServiceBal { get; }
        public IAuthenticationBal AuthenticationBal { get; }
        public IRefreshTokenBal RefreshTokenBal { get; }
        public IRegistrationBal RegistrationBal { get; }
        public IEmpAwardBal UserAwardBal { get; }
        public IEmpServiceBal EmpServiceBal { get; }
        public IQuotesBal QuotesBal { get; }
        public IEmpProjectBal EmpProjectBal { get; }
        public IEmployeeMailServiceBal EmployeeMailServiceBal { get; }
        public IEmailService EmailService { get; }
    }
}

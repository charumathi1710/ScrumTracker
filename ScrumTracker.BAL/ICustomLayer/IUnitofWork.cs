using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTracker.BAL.ICustomLayer
{
    public interface IUnitofWork
    {
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

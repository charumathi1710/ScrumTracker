using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.DependencyInjection;
using ScrumTracker.BAL.CustomLayer;
using ScrumTracker.BAL.ICustomLayer;
using ScrumTracker.DAL.DataAccessLayer;
using ScrumTracker.DAL.IDataAccessLayer;
using ScrumTracker.DataObject.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTracker.BAL
{
    public static class ServiceRegisterController
    {
        public static void AddInfracture(this IServiceCollection _service)
        {
            _service.AddScoped<ApplicationDBContext>();           

            _service.AddScoped<IUnitofWork, UnitofWork>();
            _service.AddScoped<IUnitofData, UnitofData>();

            _service.AddTransient<IUserServiceDal, UserServiceDal>();
            _service.AddTransient<IUserServiceBal, UserServiceBal>();

            _service.AddTransient<IAuthenticationDal, AuthenticationDal>();
            _service.AddTransient<IAuthenticationBal, AuthenticationBal>();

            _service.AddTransient<IRefreshTokenDal, RefreshTokenDal>();
            _service.AddTransient<IRefreshTokenBal, RefreshTokenBal>();

            _service.AddTransient<IRegistrationDal, RegistrationDal>();
            _service.AddTransient<IRegistrationBal, RegistrationBal>();

            _service.AddTransient<IEmpAwardDal, EmpAwardDal>();
            _service.AddTransient<IEmpAwardBal, EmpAwardBal>();

            _service.AddTransient<IQuotesDal, QuotesDal>();
            _service.AddTransient<IQuotesBal, QuotesBal>();

            _service.AddTransient<IEmpProjectDal, EmpProjectDal>();
            _service.AddTransient<IEmpProjectBal, EmpProjectBal>();
        }
    }       
}

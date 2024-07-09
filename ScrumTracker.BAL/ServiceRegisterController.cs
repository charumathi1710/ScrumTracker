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
        }
    }
        
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTracker.BAL.ICustomLayer
{
    public interface IEmployeeMailServiceBal
    {
        Task<string> GenerateScrumReportEmailAsync();
    }
}

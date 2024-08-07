using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTracker.BAL.ICustomLayer
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(string subject, string body, List<string> recipients);
    }
}

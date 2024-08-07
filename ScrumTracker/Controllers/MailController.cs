using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScrumTracker.BAL.ICustomLayer;
using ScrumTracker.DataObject.DataTransferObject;
using System.Net.Mail;

namespace ScrumTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IUnitofWork unitofWork;

        public MailController(IUnitofWork unitofWork)
        {
            this.unitofWork = unitofWork;
        }


        [HttpPost("send-report")]
        public async Task<IActionResult> SendReportEmail([FromBody] EmailRequest emailRequest)
        {
            if (string.IsNullOrWhiteSpace(emailRequest.To))
            {
                return BadRequest("The 'To' field is required.");
            }

            string subject = "PBT Daily Scrum Report";

            var emailContent = await unitofWork.EmployeeMailServiceBal.GenerateScrumReportEmailAsync();

            var recipients = new List<string> { emailRequest.To };
            if (emailRequest.Cc != null && emailRequest.Cc.Any())
            {
                recipients.AddRange(emailRequest.Cc);
            }

            var result = await unitofWork.EmailService.SendEmailAsync(subject, emailContent, recipients);

            if (result)
            {
                return Ok("Email sent successfully!");
            }
            else
            {
                return StatusCode(500, "Failed to send email.");
            }
        }
    }
}

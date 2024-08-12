using ScrumTracker.BAL.ICustomLayer;
using ScrumTracker.DAL.IDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTracker.BAL.CustomLayer
{
    public class EmployeeMailServiceBal:IEmployeeMailServiceBal
    {
        private readonly IUnitofData unitofData;

        public EmployeeMailServiceBal(IUnitofData unitofData)
        {
            this.unitofData = unitofData;
        }

        public async Task<string> GenerateScrumReportEmailAsync()
        {
            var employeeScrumReports = await unitofData.EmployeeRepositoryDal.GetEmployeeScrumReportAsync();
            var groupedByDept = employeeScrumReports
                .GroupBy(e => e.EmpDept)
                .ToDictionary(g => g.Key, g => g.ToList());

            var htmlContent = new StringBuilder();
            htmlContent.Append("<h2>PBT Daily Scrum Report</h2>");
            htmlContent.Append("<p>Hi Shadab,</p>");
            htmlContent.Append("<p>Please find below the PBT Team daily Scrum Meeting Report:</p>");
            htmlContent.Append($"<p><b>Date:</b> {DateTime.Now:dd/MMM/yyyy}</p>");

            foreach (var dept in groupedByDept)
            {
                htmlContent.Append($"<h2>{dept.Key} Team:</h2>");
                htmlContent.Append(@"
                <table style='border: 3px solid black; border-collapse: collapse; margin-bottom: 20px;'>
                <tr>
                    <th style='border: 3px solid black; padding: 10px;'>S.No</th>
                    <th style='border: 3px solid black; padding: 10px;'>Employee Name</th>
                    <th style='border: 3px solid black; padding: 10px;'>Project Name</th>
                    <th style='border: 3px solid black; padding: 10px;'>Billable Hours</th>
                    <th style='border: 3px solid black; padding: 10px;'>Non-Billable Hours</th>
                </tr>");

                int index = 1;
                foreach (var employee in dept.Value)
                {
                    htmlContent.Append("<tr>");
                    htmlContent.Append($"<td style='border: 3px solid black; padding: 10px;'>{index++}</td>");
                    htmlContent.Append($"<td style='border: 3px solid black; padding: 10px;'>{employee.EmpName}</td>");
                    htmlContent.Append($"<td style='border: 3px solid black; padding: 10px;'>{employee.Project}</td>");

                    htmlContent.Append($"<td style='border: 3px solid black; padding: 10px;'>{employee.Billable.TotalHours:F2}</td>");
                    htmlContent.Append($"<td style='border: 3px solid black; padding: 10px;'>{employee.NonBillable.TotalHours:F2}</td>"); 
                    htmlContent.Append("</tr>"); 
                }

                htmlContent.Append("</table>");
            }
            htmlContent.Append("<p>Thanks & Regards,</p>");
            htmlContent.Append("<p>Shannu Parveen | Project Co-Ordinator</p>");

            return htmlContent.ToString();
        }
    }
}

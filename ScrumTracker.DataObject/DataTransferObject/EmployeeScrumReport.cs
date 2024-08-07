using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTracker.DataObject.DataTransferObject
{
    public class EmployeeScrumReport
    {
        public string EmpName { get; set; }
        public string EmpDept { get; set; }
        public string Project { get; set; }
        public TimeSpan Billable { get; set; }
        public TimeSpan NonBillable { get; set; }
    }
}

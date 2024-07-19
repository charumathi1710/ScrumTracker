using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTracker.DataObject.ViewEntity
{
    public class EmpSearchStatusViewEntity
    {
        public string EmpName { get; set; }
        public string EmpCode { get; set; }
        public string EmpDept { get; set; }
        public string EmpTask { get; set; }
        public string WorkType { get; set; }
        public TimeSpan? Billable { get; set; }
        public TimeSpan? NonBillable { get; set; }
        public bool IsPresent { get; set; }

    }
}

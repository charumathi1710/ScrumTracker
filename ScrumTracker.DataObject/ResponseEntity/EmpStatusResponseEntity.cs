using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTracker.DataObject.ResponseEntity
{
    public class EmpStatusResponseEntity
    {
        public int EmpStatusId { get; set; }
        public int EmpDetailId { get; set; }
        public string EmpTask { get; set; }
        public int EmpWorkTypeId { get; set; }
        public DateTime? Billable { get; set; }
        public DateTime? NonBillable { get; set; }
        public bool IsPresent { get; set; }
        public TimeSpan? GetBillableTime()
        {
            return Billable?.TimeOfDay;

        }
        public TimeSpan? GetNonBillableTime()
        {
            return NonBillable?.TimeOfDay;
        }

    }

}

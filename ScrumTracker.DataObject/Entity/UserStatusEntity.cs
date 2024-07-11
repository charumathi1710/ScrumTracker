using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTracker.DataObject.Entity
{
    public  class UserStatusEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpCode { get; set; }
        public string EmpDept { get; set; }
        public string? EmpTask { get; set; }
        public bool? IsPresent{ get; set; }
        public string? EmpWorkType { get; set; }
        public TimeSpan? Billable { get; set;}
        public TimeSpan? NonBillable { get; set; }
        public int? UserId { get; set; }
        public int? RoleId { get; set; }
        public DateTime? Date { get; set;}
    }
}

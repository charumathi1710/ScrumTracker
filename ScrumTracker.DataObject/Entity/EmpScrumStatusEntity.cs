using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using ScrumTracker.DataObject.RequestEntity;

namespace ScrumTracker.DataObject.Entity
{
    public  class EmpScrumStatusEntity:BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpStatusId { get; set; }
        public int EmpDetailId { get; set; }
        public string EmpTask { get; set; }
        public int EmpWorkTypeId { get; set; }
        public TimeSpan? Billable { get; set; } 
        public TimeSpan? NonBillable { get; set;}
        public bool IsPresent { get; set; }
    }
}

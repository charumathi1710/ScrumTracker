using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTracker.DataObject.Entity
{
    public  class EmpDetailsEntity:BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpDetailId { get; set; }
        public string EmpName { get; set; }
        public string EmpCode { get; set; }
        public string EmpDept { get; set; }
        public string? EmpNumber { get; set; }
        public string? EmpAddress { get; set; }

    }
}

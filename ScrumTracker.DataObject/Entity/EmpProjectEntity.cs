using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTracker.DataObject.Entity
{
    public class EmpProjectEntity:BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpProjectID { get; set; }
        public int EmpDetailsID { get; set; }
        public string? FixedBid { get; set; }
        public string? TimeMaterial { get; set; }
        public string? Retainer { get; set; }
    }
}

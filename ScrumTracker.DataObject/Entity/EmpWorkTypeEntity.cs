using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTracker.DataObject.Entity
{
    public class EmpWorkTypeEntity:BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int EmpWorkTypeId { get; set; }
        public string WorkType { get; set; }
    }
}

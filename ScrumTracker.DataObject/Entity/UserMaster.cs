using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScrumTracker.Models
{
    public class UserMasterEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Emp_Code { get; set; }
        public string? Department { get; set; }
        public string? Designation { get; set; }
        public string? Work_Location { get; set; }
        public string? City { get; set; }
        public DateTime?  DOJ { get; set; }
        public string? Email_ID { get; set;}
        public string? Email_Signature { get; set; }
        public string? Reporting_To { get; set; }
        public string? IsActive { get; set;}
        public string? Windows_ID { get; set;}
        public string? Password { get; set; }

    }
    public class UserMasterViewEntity
    {
        public string? Name { get; set; }
        public string? Emp_Code { get; set; }
    }
}

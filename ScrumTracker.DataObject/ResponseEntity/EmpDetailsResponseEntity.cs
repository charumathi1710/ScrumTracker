using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTracker.DataObject.ResponseEntity
{
    public class EmpDetailsResponseEntity
    {
        public int EmpDetailId { get; set; }
        public string EmpName { get; set; }
        public string EmpCode { get; set; }
        public string EmpDept { get; set; }
        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Invalid phone number format.")]
        public string? EmpNumber { get; set; }
        public string? EmpAddress { get; set; }
        public string EmpGender { get; set; }
        public DateTime EmpDOB { get; set; }
        public string EmpDesignation { get; set; }
        public string EmpSkills { get; set; }
        public DateTime EmpJoinedOn { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email address format.")]
        public string EmpPersonalEmail { get; set; }
        public bool IsActive { get; set; }
    }
}

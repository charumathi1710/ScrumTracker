﻿using System;
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
        public string EmpGender { get; set; }
        public DateTime EmpDOB { get; set; }
        public string EmpDesignation { get; set; }
        public string EmpSkills { get; set; }
        public DateTime EmpJoinedOn { get; set; }
        public string EmpPersonalEmail { get; set; }
        public bool IsActive { get; set; }

    }
}

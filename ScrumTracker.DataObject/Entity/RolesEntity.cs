using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTracker.DataObject.Entity
{
    public class RolesEntity:BaseEntity
    {
        [Key]
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public string? RoleDescription { get; set; }
    }
}

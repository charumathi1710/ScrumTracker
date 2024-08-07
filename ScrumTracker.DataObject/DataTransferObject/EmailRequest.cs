using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTracker.DataObject.DataTransferObject
{
    public class EmailRequest
    {
        [Required]
        public string To { get; set; }
        public List<string> Cc { get; set; } = new List<string>();
    }
}

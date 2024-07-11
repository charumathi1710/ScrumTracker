using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTracker.DataObject.Entity
{
    public class BaseEntity
    {
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public string HostName { get; set; } = System.Net.Dns.GetHostName().ToString();
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}

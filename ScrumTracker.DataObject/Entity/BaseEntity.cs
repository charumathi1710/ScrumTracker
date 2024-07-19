using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ScrumTracker.DataObject.Entity
{
    public class BaseEntity
    {
        [JsonIgnore]
        public DateTime CreationDate { get; set; } = DateTime.Now;
        [JsonIgnore]
        public string HostName { get; set; } = System.Net.Dns.GetHostName().ToString();
        [JsonIgnore]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}

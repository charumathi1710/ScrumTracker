using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTracker.DataObject.ResponseEntity
{
    public class UserTokenResponseEntity
    {
        public int UsersTokenId { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public DateTime CreationDate { get; set; }
        public string HostName { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

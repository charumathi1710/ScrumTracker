using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTracker.DataObject.Entity
{
    public class UserTokenEntity:BaseEntity
    {
        [Key]
        public int UsersTokenId { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public DateTime? TokenExpiration { get; set; }
        public bool? IsTokenExpired { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public int? RoleID { get; set; }
    }
}

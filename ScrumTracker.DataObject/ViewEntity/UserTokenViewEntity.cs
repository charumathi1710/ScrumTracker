﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ScrumTracker.DataObject.ViewEntity
{
    public class UserTokenViewEntity
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int? UserRoleID { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.Core.Entities.Concrete
{
    public class RoleClaims : IEntity
    {
        public int Id { get; set; }
        public string RoleId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }
}

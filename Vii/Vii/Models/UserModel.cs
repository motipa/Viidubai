﻿using System;
using System.Collections.Generic;
using System.Text;     

namespace Vii.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string ActivationCode { get; set; }

        public bool IsVerified { get; set; }

        public Guid RoleId { get; set; }
    }
}

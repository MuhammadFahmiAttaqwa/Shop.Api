﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.DTO.Auth.Request
{
    public class RegisterRequest
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }


    }
}

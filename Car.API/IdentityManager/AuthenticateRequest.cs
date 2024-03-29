﻿using System.ComponentModel.DataAnnotations;

namespace Car.API.IdentityManager
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WirtualnyDziekanat.Infrastructure.Commands.Users
{
    public class UserCred
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

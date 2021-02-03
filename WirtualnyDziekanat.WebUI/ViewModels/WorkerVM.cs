using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WirtualnyDziekanat.WebUI.ViewModels
{
    public class WorkerVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string Username { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}

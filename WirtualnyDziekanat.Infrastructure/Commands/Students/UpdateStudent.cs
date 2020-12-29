using System;
using System.Collections.Generic;
using System.Text;

namespace WirtualnyDziekanat.Infrastructure.Commands.Students
{
    public class UpdateStudent
    {
        public Guid StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string AlbumNr { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}

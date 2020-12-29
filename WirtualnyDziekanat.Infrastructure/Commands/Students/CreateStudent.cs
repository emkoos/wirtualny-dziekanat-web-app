using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using WirtualnyDziekanat.Infrastructure.Extensions;

namespace WirtualnyDziekanat.Infrastructure.Commands.Students
{
    public class CreateStudent
    {
        public Guid StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string AlbumNr { get; set; }
        public long Pesel { get; set; }
        [Newtonsoft.Json.JsonConverter(typeof(DateTimeConverter))]
        public DateTime BirthdayDate { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;


namespace WirtualnyDziekanat.Application.DTO
{
    public class TeacherDTO
    {
        [JsonIgnore]
        public Guid ID { get; set; }
        public string AcademicTitle { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public ICollection<TeacherSubjectDTO> TeacherSubjects { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace WirtualnyDziekanat.Domain.Entities
{
    public class Teacher: Entity
    {
        public string AcademicTitle { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public ICollection<TeacherSubject> TeacherSubjects { get; set; }
            = new List<TeacherSubject>();
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace WirtualnyDziekanat.Domain.Entities
{
    public class Subject: Entity
    {
        public string Name { get; set; }
        public string Opis { get; set; }
        public ICollection<TeacherSubject> TeacherSubjects { get; set; }
            = new List<TeacherSubject>();
        public ICollection<Grade> Grades { get; set; }
    }
}

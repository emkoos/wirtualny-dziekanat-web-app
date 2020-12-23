using System;
using System.Collections.Generic;
using System.Text;

namespace WirtualnyDziekanat.Application.DTO
{
    public class SubjectDTO
    {
        public string Name { get; set; }
        public string Opis { get; set; }
        public ICollection<TeacherSubjectDTO> TeacherSubjects { get; set; }
        public ICollection<GradeDTO> Grades { get; set; }
    }
}

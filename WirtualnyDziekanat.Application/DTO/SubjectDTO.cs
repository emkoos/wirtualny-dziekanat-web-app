using System;
using System.Collections.Generic;
using System.Text;

namespace WirtualnyDziekanat.Application.DTO
{
    public class SubjectDTO
    {
        public string SubjectName { get; set; }
        public string SubjectDescribtion { get; set; }
        public ICollection<TeacherSubjectDTO> TeacherSubjects { get; set; }
            = new List<TeacherSubjectDTO>();
        public ICollection<GradeDTO> Grades { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace WirtualnyDziekanat.Application.DTO
{
    public class TeacherSubjectDTO
    {
        public Guid TeacherId { get; set; }
        public TeacherDTO Teacher { get; set; }
        public Guid SubjectId { get; set; }
        public SubjectDTO Subject { get; set; }
    }
}

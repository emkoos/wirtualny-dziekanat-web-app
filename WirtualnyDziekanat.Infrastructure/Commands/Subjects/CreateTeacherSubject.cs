using System;
using System.Collections.Generic;
using System.Text;

namespace WirtualnyDziekanat.Infrastructure.Commands.Subjects
{
    public class CreateTeacherSubject
    {
        public Guid TeacherId { get; set; }
        public Guid SubjectId { get; set; }
    }
}

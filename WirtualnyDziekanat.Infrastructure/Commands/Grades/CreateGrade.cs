using System;
using System.Collections.Generic;
using System.Text;

namespace WirtualnyDziekanat.Infrastructure.Commands.Grades
{
    public class CreateGrade
    {
        public Guid GradeId { get; set; }
        public decimal Value { get; set; }
        public Guid studentId { get; set; }
        public Guid subjectId { get; set; }
    }
}

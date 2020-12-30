using System;
using System.Collections.Generic;
using System.Text;

namespace WirtualnyDziekanat.Infrastructure.Commands.Grades
{
    public class CreateGrade
    {
        public Guid GradeId { get; set; }
        public decimal Value { get; set; }
        public Guid StudentId { get; set; }
        public Guid SubjectId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace WirtualnyDziekanat.Infrastructure.Commands.Grades
{
    public class UpdateGrade
    {
        public Guid GradeId { get; set; }
        public decimal Value { get; set; }
    }
}

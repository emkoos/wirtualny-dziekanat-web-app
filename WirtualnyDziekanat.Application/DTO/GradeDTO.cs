using System;
using System.Collections.Generic;
using System.Text;

namespace WirtualnyDziekanat.Application.DTO
{
    public class GradeDTO
    {
        public decimal Grade { get; set; }
        public StudentDTO Student { get; set; }
        public SubjectDTO Subject { get; set; }
    }
}

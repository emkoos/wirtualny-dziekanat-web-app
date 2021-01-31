using System;
using System.Collections.Generic;
using System.Text;

namespace WirtualnyDziekanat.Application.DTO
{
    public class GradeDTO
    {
        // Add AddedDate
        public decimal Value { get; set; }
        public StudentDTO Student { get; set; }
        public SubjectDTO Subject { get; set; }
    }
}

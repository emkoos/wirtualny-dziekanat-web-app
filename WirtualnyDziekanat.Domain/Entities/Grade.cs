using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WirtualnyDziekanat.Domain.Entities
{
    public class Grade: Entity
    {
        public decimal Value { get; set; }
        [ForeignKey("StudentId")]
        public Student Student { get; set; }
        public Guid StudentId { get; set; }
        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }
        public Guid SubjectId { get; set; }
    }
}

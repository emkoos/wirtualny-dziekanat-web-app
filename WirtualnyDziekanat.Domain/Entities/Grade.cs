using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WirtualnyDziekanat.Domain.Entities
{
    public class Grade: Entity
    {
        // Add AddedDate
        public decimal Value { get; set; }
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}

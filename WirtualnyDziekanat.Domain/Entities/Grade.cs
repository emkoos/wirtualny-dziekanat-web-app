using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WirtualnyDziekanat.Domain.Entities
{
    public class Grade: Entity
    {
        public decimal Value { get; set; }
        public Student Student { get; set; }
        public Subject Subject { get; set; }
    }
}

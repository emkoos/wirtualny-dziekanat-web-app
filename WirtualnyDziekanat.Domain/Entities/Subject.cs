using System;
using System.Collections.Generic;
using System.Text;

namespace WirtualnyDziekanat.Domain.Entities
{
    public class Subject: Entity
    {
        public string Name { get; set; }
        public string Opis { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
            = new List<Teacher>();
        public ICollection<Grade> Grades { get; set; }
    }
}

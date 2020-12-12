using System;
using System.Collections.Generic;
using System.Text;

namespace WirtualnyDziekanat.Domain.Entities
{
    public class Student: Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string AlbumNr { get; set; }
        public long Pesel { get; set; }
        public DateTime BirthdayDate { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<Grade> Grades { get; set; }
            = new List<Grade>();
    }
}

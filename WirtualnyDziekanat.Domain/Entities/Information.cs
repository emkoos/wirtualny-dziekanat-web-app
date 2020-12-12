using System;
using System.Collections.Generic;
using System.Text;

namespace WirtualnyDziekanat.Domain.Entities
{
    public class Information: Entity
    {
        public string Title { get; set; }
        public string Contents { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }
        public Priority PriorityStatus { get; set; }

        public enum Priority
        {
            Niski,
            Sredni,
            Wysoki
        }
    }
}

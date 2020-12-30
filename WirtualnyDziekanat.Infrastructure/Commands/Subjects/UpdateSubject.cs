using System;
using System.Collections.Generic;
using System.Text;

namespace WirtualnyDziekanat.Infrastructure.Commands.Subjects
{
    public class UpdateSubject
    {
        public Guid SubjectId { get; set; }
        public string Name { get; set; }
        public string Opis { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace WirtualnyDziekanat.Infrastructure.Commands.Informations
{
    public class UpdateInformation
    {
        public Guid InfoId { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }
        public bool IsActive { get; set; }
    }
}

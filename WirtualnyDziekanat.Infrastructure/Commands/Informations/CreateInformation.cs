using System;
using System.Collections.Generic;
using System.Text;
using static WirtualnyDziekanat.Domain.Entities.Information;

namespace WirtualnyDziekanat.Infrastructure.Commands.Informations
{
    public class CreateInformation
    {
        public Guid InfoId { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }
        public bool IsActive { get; set; }
        public Priority PriorityStatus { get; set; }
    }
}

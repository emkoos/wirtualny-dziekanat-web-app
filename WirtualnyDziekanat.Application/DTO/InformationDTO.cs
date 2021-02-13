using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using static WirtualnyDziekanat.Domain.Entities.Information;

namespace WirtualnyDziekanat.Application.DTO
{
    public class InformationDTO
    {
        [JsonIgnore]
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }
        public Priority PriorityStatus { get; set; }
    }
}

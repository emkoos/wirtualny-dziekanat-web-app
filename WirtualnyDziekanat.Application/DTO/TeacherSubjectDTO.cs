using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WirtualnyDziekanat.Application.DTO
{
    public class TeacherSubjectDTO
    {
        [JsonIgnore]
        public Guid TeacherId { get; set; }
        public TeacherDTO Teacher { get; set; }
        [JsonIgnore]
        public Guid SubjectId { get; set; }
        public SubjectDTO Subject { get; set; }
    }
}

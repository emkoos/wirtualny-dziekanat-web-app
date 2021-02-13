using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WirtualnyDziekanat.Application.DTO
{
    public class StudentDTO
    {
        [JsonIgnore]
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string AlbumNr { get; set; }
        public long Pesel { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthdayDate { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public ICollection<GradeDTO> Grades { get; set; }
    }
}

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WirtualnyDziekanat.Application.DTO;
using WirtualnyDziekanat.Domain.Entities;

namespace WirtualnyDziekanat.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Information, InformationDTO>();
                cfg.CreateMap<Student, StudentDTO>();
                cfg.CreateMap<Teacher, TeacherDTO>();
                cfg.CreateMap<Subject, SubjectDTO>();
                cfg.CreateMap<Grade, GradeDTO>();
                cfg.CreateMap<TeacherSubject, TeacherSubjectDTO>();
            }).CreateMapper();
    }
}

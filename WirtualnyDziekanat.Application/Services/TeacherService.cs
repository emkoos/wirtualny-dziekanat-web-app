using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WirtualnyDziekanat.Application.DTO;
using WirtualnyDziekanat.Domain.Entities;
using WirtualnyDziekanat.Domain.Repositories;

namespace WirtualnyDziekanat.Application.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;

        public TeacherService(ITeacherRepository teacherRepository, IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }

        public async Task<TeacherDTO> GetAsync(Guid id)
        {
            var teacher = await _teacherRepository.GetAsync(id);

            return _mapper.Map<TeacherDTO>(teacher);
        }

        public async Task<IEnumerable<TeacherDTO>> BrowseAsync(string lastName = null)
        {
            var teachers = await _teacherRepository.BrowseAsync(lastName);

            return _mapper.Map<IEnumerable<TeacherDTO>>(teachers);
        }

        public async Task CreateAsync(Guid id, string academicTitle, string firstName, string lastName, string email, string phone)
        {
            var teacher = new Teacher()
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                AcademicTitle = academicTitle,
                Email = email,
                Phone = phone
            };

            await _teacherRepository.AddAsync(teacher);
        }

        public async Task UpdateAsync(Guid id, string academicTitle, string firstName, string lastName, string email, string phone)
        {
            var teacher = await _teacherRepository.GetAsync(id);
            if (teacher == null)
            {
                throw new Exception($"Nauczyciel o identyfikatorze: '{id}' nie istnieje w systemie.");
            }

            teacher.AcademicTitle = academicTitle;
            teacher.FirstName = firstName;
            teacher.LastName = lastName;
            teacher.Email = email;
            teacher.Phone = phone;

            await _teacherRepository.UpdateAsync(teacher);
        }

        public async Task DeleteAsync(Guid id)
        {
            var teacher = await _teacherRepository.GetAsync(id);
            await _teacherRepository.DeleteAsync(teacher);
        }    
    }
}

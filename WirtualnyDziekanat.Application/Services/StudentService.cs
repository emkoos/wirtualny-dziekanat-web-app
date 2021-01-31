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
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<StudentDTO> GetStudentAsync(Guid id)
        {
            var student = await _studentRepository.GetStudentAsync(id);

            return _mapper.Map<StudentDTO>(student);
        }

        public async Task<StudentDTO> GetStudentDetailsAsync(Guid id)
        {
            var studentInfo = await _studentRepository.GetStudentDetailsAsync(id);

            return _mapper.Map<StudentDTO>(studentInfo);
        }

        public async Task<IEnumerable<StudentDTO>> BrowseStudentsAsync(string lastName = null)
        {
            var students = await _studentRepository.BrowseStudentsAsync(lastName);

            return _mapper.Map<IEnumerable<StudentDTO>>(students);
        }

        public async Task<IEnumerable<StudentDTO>> BrowseStudentsDetailsAsync(string username = null)
        {
            var studentsInfo = await _studentRepository.BrowseStudentsDetailsAsync(username);

            return _mapper.Map<IEnumerable<StudentDTO>>(studentsInfo);
        }

        public async Task CreateStudentAsync(Guid id, string firstName, string lastName, string gender, string albumNr, long pesel, DateTime birthday, string email, string address)
        {
            var student = await _studentRepository.GetStudentAsync(pesel);
            if (student != null)
            {
                throw new Exception($"Student z peselem: '{pesel}' już istnieje.");
            }

            student = new Student()
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Gender = gender,
                AlbumNr = albumNr,
                Pesel = pesel,
                BirthdayDate = birthday,
                Email = email,
                Address = address
            };

            await _studentRepository.AddStudentAsync(student);
        }

        public async Task UpdateStudentAsync(Guid id, string firstName, string lastName, string gender, string albumNr, string email, string address)
        {
            var student = await _studentRepository.GetStudentAsync(id);
            if (student == null)
            {
                throw new Exception($"Student o identyfikatorze: '{id}' nie istnieje w systemie.");
            }

            student.FirstName = firstName;
            student.LastName = lastName;
            student.Gender = gender;
            student.AlbumNr = albumNr;
            student.Email = email;
            student.Address = address;

            await _studentRepository.UpdateStudentAsync(student);
        }

        public async Task DeleteStudentAsync(Guid id)
        {
            var student = await _studentRepository.GetStudentAsync(id);
            await _studentRepository.DeleteStudentAsync(student);
        }
    }
}

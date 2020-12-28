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
    public class GradeService : IGradeService
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly IMapper _mapper;

        public GradeService(IGradeRepository gradeRepository, IMapper mapper)
        {
            _gradeRepository = gradeRepository;
            _mapper = mapper;
        }

        public async Task<GradeDTO> GetGradeAsync(Guid id)
        {
            var grade = await _gradeRepository.GetGradeAsync(id);

            return _mapper.Map<GradeDTO>(grade);
        }

        public async Task<IEnumerable<GradeDTO>> BrowseStudentGradesAsync(Guid id)
        {
            var grades = await _gradeRepository.BrowseStudentGradesAsync(id);

            return _mapper.Map<IEnumerable<GradeDTO>>(grades);
        }

        public async Task CreateAsync(Guid id, decimal value, Student student, Subject subject)
        {
            var grade = new Grade()
            {
                Id = id,
                Value = value,
                Student = student,
                Subject = subject
            };

            await _gradeRepository.AddAsync(grade);
        }

        public async Task UpdateAsync(Guid id, decimal value)
        {
            var grade = await _gradeRepository.GetGradeAsync(id);
            if (grade == null)
            {
                throw new Exception($"Ocena o identyfikatorze: '{id}' nie istnieje w systemie.");
            }

            grade.Value = value;

            await _gradeRepository.UpdateAsync(grade);
        }

        public async Task DeleteAsync(Guid id)
        {
            var grade = await _gradeRepository.GetGradeAsync(id);
            await _gradeRepository.DeleteAsync(grade);
        }
    }
}

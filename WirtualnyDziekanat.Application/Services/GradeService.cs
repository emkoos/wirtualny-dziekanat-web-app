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

        public async Task<Student> GetAsync(Guid id)
        {
            var student = await _gradeRepository.GetAsync(id);

            return student;
        }
        public async Task<IEnumerable<Student>> BrowseAsync()
        {
            var grades = await _gradeRepository.BrowseAsync();

            return _mapper.Map<IEnumerable<Student>>(grades); ;

            
        }
    }
}

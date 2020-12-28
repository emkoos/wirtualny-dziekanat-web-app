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
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IMapper _mapper;

        public SubjectService(ISubjectRepository subjectRepository, IMapper mapper)
        {
            _subjectRepository = subjectRepository;
            _mapper = mapper;
        }

        public async Task<SubjectDTO> GetAsync(Guid id)
        {
            var subject = await _subjectRepository.GetAsync(id);

            return _mapper.Map<SubjectDTO>(subject);
        }

        public async Task<IEnumerable<SubjectDTO>> BrowseAsync(string name = null)
        {
            var subjects = await _subjectRepository.BrowseAsync(name);

            return _mapper.Map<IEnumerable<SubjectDTO>>(subjects);
        }

        public async Task CreateAsync(Guid id, string name, string desc)
        {
            var subject = new Subject()
            {
                Id = id,
                Name = name,
                Opis = desc
            };

            await _subjectRepository.AddAsync(subject);
        }

        public async Task UpdateAsync(Guid id, string name, string desc)
        {
            var subject = await _subjectRepository.GetAsync(id);
            if (subject == null)
            {
                throw new Exception($"Przedmiot o identyfikatorze: '{id}' nie istnieje w systemie.");
            }

            subject.Name = name;
            subject.Opis = desc;

            await _subjectRepository.UpdateAsync(subject);
        }

        public async Task DeleteAsync(Guid id)
        {
            var subject = await _subjectRepository.GetAsync(id);
            await _subjectRepository.DeleteAsync(subject);
        }
    }
}

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WirtualnyDziekanat.Application.DTO;
using WirtualnyDziekanat.Domain.Entities;
using WirtualnyDziekanat.Domain.Repositories;
using WirtualnyDziekanat.Infrastructure.Services;

namespace WirtualnyDziekanat.Application.Services
{
    public class InformationService : IInformationService
    {
        private readonly IInformationRepository _informationRepository;
        private readonly IMapper _mapper;

        public InformationService(IInformationRepository informationRepository, IMapper mapper)
        {
            _informationRepository = informationRepository;
            _mapper = mapper;
        }

        public async Task<InformationDTO> GetAsync(Guid id)
        {
            var information = await _informationRepository.GetAsync(id);

            return _mapper.Map<InformationDTO>(information);
        }

        public async Task<IEnumerable<InformationDTO>> BrowseAsync(string title = null)
        {
            var informations = await _informationRepository.BrowseAsync(title);

            return _mapper.Map<IEnumerable<InformationDTO>>(informations);
        }

        public async Task CreateAsync(Guid id, string title, string contents, bool isActive, Information.Priority status)
        {
            var information = new Information()
            {
                Id = id,
                Title = title,
                Contents = contents,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                IsActive = isActive,
                PriorityStatus = status
            };
            await _informationRepository.AddAsync(information);
        }

        public async Task UpdateAsync(Guid id, string title, string contents, bool isActive)
        {
            var information = await _informationRepository.GetAsync(id);
            if (information == null)
            {
                throw new Exception($"Informacja o numerze: '{id}' nie istnieje w systemie.");
            }

            information.Title = title;
            information.Contents = contents;
            information.IsActive = isActive;
            information.UpdatedAt = DateTime.UtcNow;

            await _informationRepository.UpdateAsync(information);
        }

        public async Task DeleteAsync(Guid id)
        {
            var information = await _informationRepository.GetAsync(id);
            await _informationRepository.DeleteAsync(information);
        }
    }
}

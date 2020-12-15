using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WirtualnyDziekanat.Application.DTO;
using static WirtualnyDziekanat.Domain.Entities.Information;

namespace WirtualnyDziekanat.Infrastructure.Services
{
    public interface IInformationService
    {
        Task<InformationDTO> GetAsync(Guid id);
        Task<IEnumerable<InformationDTO>> BrowseAsync(string title = null);
        Task CreateAsync(Guid id, string title, string contents, bool isActive, Priority status);
        Task UpdateAsync(Guid id, string title, string contents, bool isActive);
        Task DeleteAsync(Guid id);
    }
}

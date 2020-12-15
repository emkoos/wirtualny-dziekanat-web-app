using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WirtualnyDziekanat.Domain.Entities;

namespace WirtualnyDziekanat.Domain.Repositories
{
    public interface IInformationRepository
    {
        Task<Information> GetAsync(Guid id);
        Task<IEnumerable<Information>> BrowseAsync(string title = "");
        Task AddAsync(Information information);
        Task UpdateAsync(Information information);
        Task DeleteAsync(Information information);
    }
}

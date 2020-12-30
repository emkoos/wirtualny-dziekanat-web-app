using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WirtualnyDziekanat.Application.DTO;

namespace WirtualnyDziekanat.Application.Services
{
    public interface ISubjectService
    {
        Task<SubjectDTO> GetAsync(Guid id);
        Task<IEnumerable<SubjectDTO>> BrowseAsync(string name = null);
        Task CreateAsync(Guid id, string name, string desc);
        Task UpdateAsync(Guid id, string name, string desc);
        Task DeleteAsync(Guid id);
        Task BindTeacherSubject(Guid id1, Guid id2);
    }
}

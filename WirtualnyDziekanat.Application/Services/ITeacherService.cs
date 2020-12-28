using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WirtualnyDziekanat.Application.DTO;

namespace WirtualnyDziekanat.Application.Services
{
    public interface ITeacherService
    {
        Task<TeacherDTO> GetAsync(Guid id);
        Task<IEnumerable<TeacherDTO>> BrowseAsync(string lastName = null);
        Task CreateAsync(Guid id, string academicTitle, string firstName, string lastName, string email, string phone);
        Task UpdateAsync(Guid id, string academicTitle, string firstName, string lastName, string email, string phone);
        Task DeleteAsync(Guid id);
    }
}

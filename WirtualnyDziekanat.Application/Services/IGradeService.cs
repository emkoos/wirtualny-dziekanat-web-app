using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WirtualnyDziekanat.Application.DTO;
using WirtualnyDziekanat.Domain.Entities;

namespace WirtualnyDziekanat.Application.Services
{
    public interface IGradeService
    {
        Task<Student> GetAsync(Guid id);
        Task<IEnumerable<StudentDTO>> BrowseAsync();
    }
}

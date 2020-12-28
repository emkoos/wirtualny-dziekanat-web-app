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
        Task<GradeDTO> GetGradeAsync(Guid id);
        Task<IEnumerable<GradeDTO>> BrowseStudentGradesAsync(Guid id); // wszystkie oceny danego studenta
        Task CreateAsync(Guid id, decimal value, Guid studentId, Guid subjectId);
        Task UpdateAsync(Guid id, decimal value);
        Task DeleteAsync(Guid id);
    }
}

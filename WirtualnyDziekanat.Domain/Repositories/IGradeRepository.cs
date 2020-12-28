using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WirtualnyDziekanat.Domain.Entities;

namespace WirtualnyDziekanat.Domain.Repositories
{
    public interface IGradeRepository
    {
        Task<Grade> GetGradeAsync(Guid id); // szczegóły 1 oceny /grades/{idGrade}  :przedmiot i nauczyciel
        Task<IEnumerable<Grade>> BrowseStudentGradesAsync(Guid id); // wszystkie oceny danego studenta
        Task AddAsync(Grade grade);
        Task UpdateAsync(Grade graden);
        Task DeleteAsync(Grade grade);  
    }
}

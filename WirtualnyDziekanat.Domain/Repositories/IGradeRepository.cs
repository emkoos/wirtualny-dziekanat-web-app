using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WirtualnyDziekanat.Domain.Entities;

namespace WirtualnyDziekanat.Domain.Repositories
{
    public interface IGradeRepository
    {
        Task<Grade> GetGradeAsync(Guid id); 
        Task<IEnumerable<Grade>> BrowseStudentGradesAsync(Guid id); 
        Task AddAsync(Grade grade);
        Task UpdateAsync(Grade grade);
        Task DeleteAsync(Grade grade);  
    }
}

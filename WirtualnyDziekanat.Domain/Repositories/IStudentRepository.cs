using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WirtualnyDziekanat.Domain.Entities;

namespace WirtualnyDziekanat.Domain.Repositories
{
    public interface IStudentRepository
    {
        // One model data
        Task<Student> GetStudentAsync(Guid id);   
        Task<Student> GetStudentAsync(long pesel);
        Task<IEnumerable<Student>> BrowseStudentsAsync(string lastName = "");
        Task AddStudentAsync(Student student); 
        Task UpdateStudentAsync(Student student); 
        Task DeleteStudentAsync(Student student); 
        // Models tree of data
        Task<Student> GetStudentDetailsAsync(Guid id);  
        Task<IEnumerable<Student>> BrowseStudentsDetailsAsync(); 
    }
}

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
        Task<Student> GetStudentAsync(Guid id);   // dane 1 studenta
        Task<IEnumerable<Student>> BrowseStudentsAsync(string lastName = ""); // lista wszystkich studentów
        Task AddStudentAsync(Student student); // dodanie danych 1 studenta
        Task UpdateStudentAsync(Student student); // edycja danych 1 studenta
        Task DeleteStudentAsync(Student student); // usunięcie 1 studenta
        // Models trees of data
        Task<Student> GetStudentDetailsAsync(Guid id);  // Drzewko dla 1 studenta
        Task<IEnumerable<Student>> BrowseStudentsDetailsAsync(); // Drzewko dla wszystkich studentów
    }
}

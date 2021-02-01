using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WirtualnyDziekanat.Application.DTO;

namespace WirtualnyDziekanat.Application.Services
{
    public interface IStudentService
    {
        // One model data
        Task<StudentDTO> GetStudentAsync(Guid id);
        Task<IEnumerable<StudentDTO>> BrowseStudentsAsync(string lastName = null);
        Task CreateStudentAsync(Guid id, string firstName, string lastName, string gender, string albumNr, 
            long pesel, DateTime birthday, string email, string address);
        Task UpdateStudentAsync(Guid id, string firstName, string lastName, string gender, string albumNr, string email, string address);
        Task DeleteStudentAsync(Guid id);
        // Models tree of data
        Task<StudentDTO> GetStudentDetailsAsync(Guid id);
        Task<StudentDTO> GetStudentDetailsAsync(string username);
        Task<IEnumerable<StudentDTO>> BrowseStudentsDetailsAsync();
    }
}

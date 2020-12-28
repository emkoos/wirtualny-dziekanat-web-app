using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WirtualnyDziekanat.Domain.Entities;
using WirtualnyDziekanat.Domain.Repositories;
using WirtualnyDziekanat.Infrastructure.Data;

namespace WirtualnyDziekanat.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Student> GetStudentAsync(Guid id)
            => await Task.FromResult(_context.Students.SingleOrDefault(x => x.Id == id));

        public async Task<Student> GetStudentDetailsAsync(Guid id)
        {
            var student = _context.Students
                .Include(s => s.Grades)
                    .ThenInclude(g => g.Subject)
                        .ThenInclude(n => n.TeacherSubjects)
                            .ThenInclude(s => s.Teacher)
                .SingleOrDefault(x => x.Id == id);

            return await Task.FromResult(student);
        }

        public async Task<IEnumerable<Student>> BrowseStudentsAsync(string lastName = "")
        {
            var students = _context.Students.AsEnumerable();
            if (!string.IsNullOrWhiteSpace(lastName))
            {
                students = students.Where(s => s.LastName.ToLowerInvariant()
                                           .Contains(lastName.ToLowerInvariant()));
            }
            return await Task.FromResult(students);
        }

        public async Task<IEnumerable<Student>> BrowseStudentsDetailsAsync()
        {
            var students = _context.Students
                .Include(s => s.Grades)
                    .ThenInclude(g => g.Subject)
                        .ThenInclude(n => n.TeacherSubjects)
                            .ThenInclude(s => s.Teacher)
                .AsEnumerable();

            return await Task.FromResult(students);
        }

        public async Task AddStudentAsync(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            await Task.CompletedTask;
        }

        public async Task UpdateStudentAsync(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
            await Task.CompletedTask;
        }

        public async Task DeleteStudentAsync(Student student)
        {
            var studentGrades = _context.Grades.Where(g => g.Student.Id == student.Id).ToList();

            if(studentGrades != null)
            {
                foreach (var s in studentGrades)
                {
                    _context.Grades.Remove(s);
                }
            }

            _context.Students.Remove(student);
            _context.SaveChanges();
            await Task.CompletedTask;
        }
    }
}

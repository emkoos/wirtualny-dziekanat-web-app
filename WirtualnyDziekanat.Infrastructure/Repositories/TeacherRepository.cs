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
    public class TeacherRepository : ITeacherRepository
    {
        private readonly AppDbContext _context;

        public TeacherRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Teacher> GetAsync(Guid id)
            => await Task.FromResult(_context.Teachers.SingleOrDefault(x => x.Id == id));

        public async Task<IEnumerable<Teacher>> BrowseAsync(string lastName = "")
        {
            var teachers = _context.Teachers.AsEnumerable();
            if (!string.IsNullOrWhiteSpace(lastName))
            {
                teachers = teachers.Where(s => s.LastName.ToLowerInvariant()
                                           .Contains(lastName.ToLowerInvariant()));
            }
            return await Task.FromResult(teachers);
        }

        public async Task AddAsync(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            _context.SaveChanges();
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Teacher teacher)
        {
            _context.Teachers.Update(teacher);
            _context.SaveChanges();
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Teacher teacher)
        {
            var teacherSubjects = _context.TeacherSubjects.Where(t => t.TeacherId == teacher.Id).ToList();

            if (teacherSubjects != null)
            {
                foreach (var st in teacherSubjects)
                {
                    _context.TeacherSubjects.Remove(st);
                }
            }

            _context.Teachers.Remove(teacher);
            _context.SaveChanges();
            await Task.CompletedTask;
        }  
    }
}

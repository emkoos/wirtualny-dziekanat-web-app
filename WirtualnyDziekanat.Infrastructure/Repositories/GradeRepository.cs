using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using WirtualnyDziekanat.Domain.Entities;
using WirtualnyDziekanat.Domain.Repositories;
using WirtualnyDziekanat.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace WirtualnyDziekanat.Infrastructure.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private readonly AppDbContext _context;

        public GradeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Student> GetAsync(Guid id)
        {
            var student = _context.Students
                .Include(s => s.Grades)
                    .ThenInclude(t => t.Subject)
                        .ThenInclude(n => n.TeacherSubjects)
                            .ThenInclude(n => n.Teacher)
                .SingleOrDefault(x => x.Id == id);

            return await Task.FromResult(student);
        }

        public async Task<IEnumerable<Student>> BrowseAsync()
        {
            var students = _context.Students
                .Include(g => g.Grades)
                    .ThenInclude(s => s.Subject)
                        .ThenInclude(ts => ts.TeacherSubjects)
                            .ThenInclude(t => t.Teacher)
                .AsEnumerable();

            return await Task.FromResult(students);
        }

        public void Add(Grade grade)
        {
            throw new NotImplementedException();
        }

        

        public void Delete(Grade grade)
        {
            throw new NotImplementedException();
        }

        

        public void Update(Grade graden)
        {
            throw new NotImplementedException();
        }
    }
}

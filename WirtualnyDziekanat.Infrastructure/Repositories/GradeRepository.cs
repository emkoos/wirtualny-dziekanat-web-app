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

        public async Task<Grade> GetGradeAsync(Guid id)
        {
            var grade = _context.Grades
                .Include(g => g.Subject)
                        .ThenInclude(n => n.TeacherSubjects)
                            .ThenInclude(s => s.Teacher)
                .SingleOrDefault(x => x.Id == id);

            return await Task.FromResult(grade);
        }

        public async Task<IEnumerable<Grade>> BrowseStudentGradesAsync(Guid id)
        {
            var grades = _context.Grades.Where(g => g.Student.Id == id).AsEnumerable();
            
            return await Task.FromResult(grades);
        }

        public async Task AddAsync(Grade grade)
        {
            _context.Grades.Add(grade);
            _context.SaveChanges();
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Grade grade)
        {
            _context.Grades.Update(grade);
            _context.SaveChanges();
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Grade grade)
        {
            _context.Grades.Remove(grade);
            _context.SaveChanges();
            await Task.CompletedTask;
        }        
    }
}

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
    public class SubjectRepository: ISubjectRepository
    {
        private readonly AppDbContext _context;

        public SubjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Subject> GetAsync(Guid id)
        {
            var subject = _context.Subjects
                .Include(s => s.TeacherSubjects)
                    .ThenInclude(t => t.Teacher)
                .SingleOrDefault(x => x.Id == id);

            return await Task.FromResult(subject);
        }

        public async Task<IEnumerable<Subject>> BrowseAsync(string name = "")
        {
             var subjects = _context.Subjects
                .Include(s => s.TeacherSubjects)
                    .ThenInclude(t => t.Teacher)
                .AsEnumerable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                subjects = subjects.Where(s => s.Name.ToLowerInvariant().Contains(name.ToLowerInvariant()));
            }

            return await Task.FromResult(subjects);
        }

        public async Task AddAsync(Subject subject)
        {
            _context.Subjects.Add(subject);
            _context.SaveChanges();
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Subject subject)
        {
            _context.Subjects.Update(subject);
            _context.SaveChanges();
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Subject subject)
        {
            var subjectTeachers = _context.TeacherSubjects.Where(s => s.SubjectId == subject.Id).ToList();

            if (subjectTeachers != null)
            {
                foreach (var st in subjectTeachers)
                {
                    _context.TeacherSubjects.Remove(st);
                }
            }

            _context.Subjects.Remove(subject);
            _context.SaveChanges();
            await Task.CompletedTask;
        }

        public async Task AddSubjectTeachers(TeacherSubject teacherSubject)
        {
            _context.TeacherSubjects.Add(teacherSubject);
            _context.SaveChanges();
            await Task.CompletedTask;
        }
    }
}

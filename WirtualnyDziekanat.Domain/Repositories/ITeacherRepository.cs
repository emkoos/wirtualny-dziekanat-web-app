using System;
using System.Collections.Generic;
using System.Text;
using WirtualnyDziekanat.Domain.Entities;

namespace WirtualnyDziekanat.Domain.Repositories
{
    public interface ITeacherRepository
    {
        Teacher Get(Guid id);
        IEnumerable<Teacher> Browse(string lastName = "");
        void Add(Teacher teacher);
        void Update(Teacher teacher);
        void Delete(Teacher teacher);
    }
}

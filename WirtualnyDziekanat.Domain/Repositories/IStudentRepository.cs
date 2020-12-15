using System;
using System.Collections.Generic;
using System.Text;
using WirtualnyDziekanat.Domain.Entities;

namespace WirtualnyDziekanat.Domain.Repositories
{
    public interface IStudentRepository
    {
        Student Get(Guid id);
        IEnumerable<Student> Browse(string lastName = "");
        void Add(Student student);
        void Update(Student student);
        void Delete(Student student);
    }
}

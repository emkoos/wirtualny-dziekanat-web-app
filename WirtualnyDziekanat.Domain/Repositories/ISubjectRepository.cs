using System;
using System.Collections.Generic;
using System.Text;
using WirtualnyDziekanat.Domain.Entities;

namespace WirtualnyDziekanat.Domain.Repositories
{
    public interface ISubjectRepository
    {
        Subject Get(Guid id);
        IEnumerable<Subject> Browse(string name = "");
        void Add(Subject subject);
        void Update(Subject subject);
        void Delete(Subject subject);
    }
}

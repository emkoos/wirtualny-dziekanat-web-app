using System;
using System.Collections.Generic;
using System.Text;
using WirtualnyDziekanat.Domain.Entities;

namespace WirtualnyDziekanat.Domain.Repositories
{
    public interface IGradeRepository
    {
        Grade Get(Guid id);
        IEnumerable<Grade> Browse(decimal val);
        void Add(Grade grade);
        void Update(Grade graden);
        void Delete(Grade grade);
    }
}

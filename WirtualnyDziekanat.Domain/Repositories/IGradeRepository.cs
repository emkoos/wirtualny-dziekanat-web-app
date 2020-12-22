﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WirtualnyDziekanat.Domain.Entities;

namespace WirtualnyDziekanat.Domain.Repositories
{
    public interface IGradeRepository
    {
        Task<Student> GetAsync(Guid id);
        Task<IEnumerable<Student>> BrowseAsync();
        void Add(Grade grade);
        void Update(Grade graden);
        void Delete(Grade grade);
    }
}

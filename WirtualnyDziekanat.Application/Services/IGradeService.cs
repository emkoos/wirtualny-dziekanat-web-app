﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WirtualnyDziekanat.Application.DTO;
using WirtualnyDziekanat.Domain.Entities;

namespace WirtualnyDziekanat.Application.Services
{
    public interface IGradeService
    {
        Task<GradeDTO> GetGradeAsync(Guid id);
        Task<IEnumerable<GradeDTO>> BrowseStudentGradesAsync(Guid id);
        Task CreateAsync(Guid id, decimal value, Guid id2, Guid id3);
        Task UpdateAsync(Guid id, decimal value);
        Task DeleteAsync(Guid id);
    }
}

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WirtualnyDziekanat.Application.Services;
using WirtualnyDziekanat.Infrastructure.Commands.Subjects;

namespace WirtualnyDziekanat.WebUI.Api
{
    [ResponseCache(Duration = 60, Location = ResponseCacheLocation.None)]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SubjectsController : Controller
    {
        private readonly ISubjectService _subjectService;

        public SubjectsController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            var subjects = await _subjectService.BrowseAsync();

            return Json(subjects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var subject = await _subjectService.GetAsync(id);
            if (subject == null)
            {
                return NotFound();
            }

            return Json(subject);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateSubject command)
        {
            command.SubjectId = Guid.NewGuid();
            await _subjectService.CreateAsync(command.SubjectId, command.Name, command.Opis);

            // Code 201
            return Created($"/subjects/{command.SubjectId}", null);
        }

        [Route("/teacherSubject")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTeacherSubject command)
        {
            await _subjectService.BindTeacherSubject(command.TeacherId, command.SubjectId);

            // Code 201
            return Created($"Referenced Teacher:{command.TeacherId} and Subject: {command.SubjectId}", null);
        }

        [HttpPut("{subjectId}")]
        public async Task<IActionResult> Put(Guid subjectId, [FromBody]UpdateSubject command)
        {
            await _subjectService.UpdateAsync(subjectId, command.Name, command.Opis);

            // Code 204
            return NoContent();
        }

        [HttpDelete("{subjectId}")]
        public async Task<IActionResult> Delete(Guid subjectId)
        {
            await _subjectService.DeleteAsync(subjectId);

            // Code 204
            return NoContent();
        }
    }
}

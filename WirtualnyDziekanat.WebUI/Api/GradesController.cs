using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WirtualnyDziekanat.Application.Services;
using WirtualnyDziekanat.Infrastructure.Commands.Grades;

namespace WirtualnyDziekanat.WebUI.Api
{
    [Route("[controller]")]
    public class GradesController : Controller
    {
        private readonly IGradeService _gradeService;

        public GradesController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        [HttpGet("{gradeId}")]
        public async Task<IActionResult> Get(Guid gradeId)
        {
            var grade = await _gradeService.GetGradeAsync(gradeId);
            if (grade == null)
            {
                return NotFound();
            }

            return Json(grade);
        }

        [Route("/grades/students")]
        [HttpGet("/grades/students/{studentId}")]
        public async Task<IActionResult> GetAll(Guid studentId)
        {
            var grades = await _gradeService.BrowseStudentGradesAsync(studentId);

            return Json(grades);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateGrade command)
        {
            command.GradeId = Guid.NewGuid();
            await _gradeService.CreateAsync(command.GradeId, command.Value, command.StudentId, command.SubjectId);

            // Code 201
            return Created($"/grades/{command.GradeId}", null);
        }

        [HttpPut("{gradeId}")]
        public async Task<IActionResult> Put(Guid gradeId, [FromBody] UpdateGrade command)
        {
            await _gradeService.UpdateAsync(gradeId, command.Value);

            // Code 204
            return NoContent();
        }

        [HttpDelete("{gradeId}")]
        public async Task<IActionResult> Delete(Guid gradeId)
        {
            await _gradeService.DeleteAsync(gradeId);

            // Code 204
            return NoContent();
        }
    }
}

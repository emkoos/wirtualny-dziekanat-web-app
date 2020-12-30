using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WirtualnyDziekanat.Application.Services;
using WirtualnyDziekanat.Infrastructure.Commands.Teachers;

namespace WirtualnyDziekanat.WebUI.Api
{
    [Route("[controller]")]
    public class TeachersController : Controller
    {
        private readonly ITeacherService _teacherService;

        public TeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var subjects = await _teacherService.BrowseAsync();

            return Json(subjects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var teacher = await _teacherService.GetAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }

            return Json(teacher);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTeacher command)
        {
            command.TeacherId = Guid.NewGuid();
            await _teacherService.CreateAsync(command.TeacherId, command.AcademicTitle, command.FirstName, command.LastName, command.Email, command.Phone);

            // Code 201
            return Created($"/teachers/{command.TeacherId}", null);
        }

        [HttpPut("{teacherId}")]
        public async Task<IActionResult> Put(Guid teacherId, [FromBody] UpdateTeacher command)
        {
            await _teacherService.UpdateAsync(teacherId, command.AcademicTitle, command.FirstName, command.LastName, command.Email, command.Phone);

            // Code 204
            return NoContent();
        }

        [HttpDelete("{teacherId}")]
        public async Task<IActionResult> Delete(Guid teacherId)
        {
            await _teacherService.DeleteAsync(teacherId);

            // Code 204
            return NoContent();
        }
    }
}

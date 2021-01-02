using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WirtualnyDziekanat.Application.Services;
using WirtualnyDziekanat.Infrastructure.Commands.Students;

namespace WirtualnyDziekanat.WebUI.Api
{
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IGradeService _gradeService;

        public StudentsController(IStudentService studentService, IGradeService gradeService)
        {
            _studentService = studentService;
            _gradeService = gradeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string lastName)
        {
            var students = await _studentService.BrowseStudentsAsync(lastName);

            return Json(students);
        }
        
        [HttpGet("{studentId}")]
        public async Task<IActionResult> Get(Guid studentId)
        {
            var student = await _studentService.GetStudentAsync(studentId);
            if (student == null)
            {
                return NotFound();
            }

            return Json(student);
        }

        [Route("/studentsDetails")]
        [HttpGet]
        public async Task<IActionResult> GetDetails()
        {
            var students = await _studentService.BrowseStudentsDetailsAsync();

            return Json(students);
        }

        [Route("/studentsDetails")]
        [HttpGet("/studentsDetails/{studentID}")]
        public async Task<IActionResult> GetDetails(Guid studentID)
        {
            var student = await _studentService.GetStudentDetailsAsync(studentID);
            if (student == null)
            {
                return NotFound();
            }

            return Json(student);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateStudent command)
        {
            command.StudentId = Guid.NewGuid();
            await _studentService.CreateStudentAsync(command.StudentId, command.FirstName, command.LastName, command.Gender, 
                command.AlbumNr, command.Pesel, DateTime.Now, command.Email, command.Address);

            // Code 201
            return Created($"/students/{command.StudentId}", null);
        }

        [HttpPut("{studentId}")]
        public async Task<IActionResult> Put(Guid studentId, [FromBody]UpdateStudent command)
        {
            await _studentService.UpdateStudentAsync(studentId, command.FirstName, command.LastName, command.Gender, command.AlbumNr, 
                command.Email, command.Address);

            // Code 204
            return NoContent();
        }

        [HttpDelete("{studentId}")]
        public async Task<IActionResult> Delete(Guid studentId)
        {
            await _studentService.DeleteStudentAsync(studentId);

            // Code 204
            return NoContent();
        }
    }
}

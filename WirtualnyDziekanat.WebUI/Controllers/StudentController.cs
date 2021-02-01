using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WirtualnyDziekanat.Application.Services;

namespace WirtualnyDziekanat.WebUI.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _logger;
        private readonly ISubjectService _subjectService;
        private readonly IStudentService _studentService;

        public StudentController(ILogger<StudentController> logger, ISubjectService subjectService, IStudentService studentService)
        {
            _logger = logger;
            _subjectService = subjectService;
            _studentService = studentService;
        }

        public async Task<IActionResult> Subjects()
        {
            var subjects = await _subjectService.BrowseAsync();

            return View(subjects);
        }

        public async Task<IActionResult> Grades()
        {
            var grades = await _studentService.GetStudentDetailsAsync(User.Identity.Name);

            return View(grades);
        }

        public async Task<IActionResult> Data()
        {
            var studentData = await _studentService.GetStudentDetailsAsync(User.Identity.Name);
            
            return View(studentData);
        }
    }
}

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
    [Authorize(Roles = "Worker")]
    public class PanelController : Controller
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IStudentService _studentService;
        private readonly ISubjectService _subjectService;
        private readonly ITeacherService _teacherService;

        public PanelController(ILogger<StudentController> logger, IStudentService studentService, ISubjectService subjectService, ITeacherService teacherService)
        {
            _logger = logger;
            _studentService = studentService;
            _subjectService = subjectService;
            _teacherService = teacherService;
        }

        public async Task<IActionResult> Panel()
        {
            return View();
        }

        public async Task<IActionResult> Students()
        {
            var students = await _studentService.BrowseStudentsAsync();

            return View(students);
        }

        public async Task<IActionResult> Subjects()
        {
            var subjects = await _subjectService.BrowseAsync();

            return View(subjects);
        }

        public async Task<IActionResult> Teachers()
        {
            var teachers = await _teacherService.BrowseAsync();

            return View(teachers);
        }
    }
}

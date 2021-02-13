using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WirtualnyDziekanat.Application.DTO;
using WirtualnyDziekanat.Application.Services;
using WirtualnyDziekanat.Domain.Entities;

namespace WirtualnyDziekanat.WebUI.Controllers
{
    [Authorize(Roles = "Worker")]
    public class PanelController : Controller
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IStudentService _studentService;
        private readonly ISubjectService _subjectService;
        private readonly ITeacherService _teacherService;
        private readonly UserManager<User> _userManager;

        public PanelController(ILogger<StudentController> logger, IStudentService studentService, ISubjectService subjectService, ITeacherService teacherService, UserManager<User> userManager)
        {
            _logger = logger;
            _studentService = studentService;
            _subjectService = subjectService;
            _teacherService = teacherService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Panel()
        {
            return View();
        }

        // STUDENTS:
        public async Task<IActionResult> Students()
        {
            var students = await _studentService.BrowseStudentsAsync();

            return View(students);
        }

        [HttpGet]
        public async Task<IActionResult> CreateStudent()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(StudentDTO model)
        {
            if (ModelState.IsValid)
            {
                model.ID = Guid.NewGuid();
                await _studentService.CreateStudentAsync(model.ID, model.FirstName, model.LastName, model.Gender, model.AlbumNr, model.Pesel, model.BirthdayDate, model.Email, model.Address);

                // Create user 
                var user = await _userManager.FindByNameAsync(model.Email);

                if (user == null)
                {
                    user = new User()
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        UserName = model.Email
                    };

                    var temporaryPassword = "Student@" + model.Pesel.ToString();

                    var result = await _userManager.CreateAsync(user, temporaryPassword);
                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, "Student");
                        TempData["message"] = "Dodano nowego studenta w grupie Student";
                        return RedirectToAction("Panel");
                    }
                    TempData["message"] = "Błąd z utworzeniem użytkownika";
                    return RedirectToAction("Panel");
                }
            }
            TempData["message_fail"] = "Coś poszło nie tak...";
            return View();
        }

        //TEACHERS:
        public async Task<IActionResult> Teachers()
        {
            var teachers = await _teacherService.BrowseAsync();

            return View(teachers);
        }

        [HttpGet]
        public async Task<IActionResult> CreateTeacher()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeacher(TeacherDTO model)
        {
            if (ModelState.IsValid)
            {
                model.ID = Guid.NewGuid();
                await _teacherService.CreateAsync(model.ID, model.AcademicTitle, model.FirstName, model.LastName, model.Email, model.Phone);

                TempData["message"] = "Dodano nowego prowadzącego";
                return RedirectToAction("Panel");
            }

            TempData["message_fail"] = "Coś poszło nie tak...";
            return View();
        }

        [HttpGet]
        [Route("/Panel/EditTeacher/{id}")]
        public async Task<IActionResult> EditTeacher(Guid id)
        {
            var teacher = await _teacherService.GetAsync(id);

            return View(teacher);
        }

        [HttpPost]
        public async Task<IActionResult> EditTeacher(TeacherDTO model)
        {
            if (ModelState.IsValid)
            {
                await _teacherService.UpdateAsync(model.ID, model.AcademicTitle, model.FirstName, model.LastName, model.Email, model.Phone);

                TempData["message"] = "Zaktualizowano prowadzącego";
                return RedirectToAction("Panel");
            }

            TempData["updated_fail"] = "Coś poszło nie tak...";
            return View();
        }

        [Route("/Panel/DeleteTeacher/{id}")]
        public async Task<IActionResult> DeleteTeacher(Guid id)
        {
            await _teacherService.DeleteAsync(id);

            TempData["message"] = "Usunięto prowadzącego";
            return RedirectToAction("Panel", "Panel");
        }

        // SUBJECTS:
        public async Task<IActionResult> Subjects()
        {
            var subjects = await _subjectService.BrowseAsync();

            return View(subjects);
        }

        [HttpGet]
        public async Task<IActionResult> CreateSubject()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubject(SubjectDTO model)
        {
            if (ModelState.IsValid)
            {
                model.ID = Guid.NewGuid();
                await _subjectService.CreateAsync(model.ID, model.Name, model.Opis);

                TempData["message"] = "Dodano nowy przedmiot";
                return RedirectToAction("Panel");
            }

            TempData["message_fail"] = "Coś poszło nie tak...";
            return View();
        }

        [HttpGet]
        [Route("/Panel/EditSubject/{id}")]
        public async Task<IActionResult> EditSubject(Guid id)
        {
            var subject = await _subjectService.GetAsync(id);

            return View(subject);
        }

        [HttpPost]
        public async Task<IActionResult> EditSubject(SubjectDTO model)
        {
            if (ModelState.IsValid)
            {
                await _subjectService.UpdateAsync(model.ID, model.Name, model.Opis);

                TempData["message"] = "Zaktualizowano przedmiot";
                return RedirectToAction("Panel");
            }

            TempData["updated_fail"] = "Coś poszło nie tak...";
            return View();
        }

        [Route("/Panel/DeleteSubject/{id}")]
        public async Task<IActionResult> DeleteSubject(Guid id)
        {
            await _subjectService.DeleteAsync(id);

            TempData["message"] = "Usunięto prowadzącego";
            return RedirectToAction("Panel", "Panel");
        }
    }
}

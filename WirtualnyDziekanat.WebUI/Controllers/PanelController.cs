﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WirtualnyDziekanat.Application.DTO;
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

                TempData["message_success"] = "Dodano nowy przedmiot";
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

                TempData["message_success"] = "Zaktualizowano przedmiot";
                return RedirectToAction("Panel");
            }

            TempData["updated_fail"] = "Coś poszło nie tak...";
            return View();
        }

        [Route("/Panel/DeleteSubject/{id}")]
        public async Task<IActionResult> DeleteSubject(Guid id)
        {
            await _subjectService.DeleteAsync(id);

            TempData["message_success"] = "Usunięto prowadzącego";
            return RedirectToAction("Panel", "Panel");
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

                TempData["message_success"] = "Dodano nowego prowadzącego";
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

                TempData["message_success"] = "Zaktualizowano prowadzącego";
                return RedirectToAction("Panel");
            }

            TempData["updated_fail"] = "Coś poszło nie tak...";
            return View();
        }

        [Route("/Panel/DeleteTeacher/{id}")]
        public async Task<IActionResult> DeleteTeacher(Guid id)
        {
            await _teacherService.DeleteAsync(id);

            TempData["message_success"] = "Usunięto prowadzącego";
            return RedirectToAction("Panel", "Panel");
        }
    }
}

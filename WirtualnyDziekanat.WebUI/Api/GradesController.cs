using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WirtualnyDziekanat.Application.Services;

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

        [Route("/gradesDetails")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var grades = await _gradeService.BrowseAsync();

            return Json(grades);
        }
    }
}

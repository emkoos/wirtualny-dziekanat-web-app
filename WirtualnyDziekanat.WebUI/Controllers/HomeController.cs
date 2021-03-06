﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WirtualnyDziekanat.Infrastructure.Services;
using WirtualnyDziekanat.WebUI.Models;

namespace WirtualnyDziekanat.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IInformationService _informationService;

        public HomeController(ILogger<HomeController> logger, IInformationService informationService)
        {
            _logger = logger;
            _informationService = informationService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string name)
        {
            var informations = await _informationService.BrowseAsync(name);

            return View(informations);
        }
    }
}

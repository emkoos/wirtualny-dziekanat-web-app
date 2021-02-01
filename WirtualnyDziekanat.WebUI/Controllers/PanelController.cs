using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WirtualnyDziekanat.WebUI.Controllers
{
    [Authorize(Roles = "Worker")]
    public class PanelController : Controller
    {
        
        public IActionResult Panel()
        {
            return View();
        }
    }
}

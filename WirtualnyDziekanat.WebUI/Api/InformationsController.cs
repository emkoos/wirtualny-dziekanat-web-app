using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WirtualnyDziekanat.Infrastructure.Commands.Informations;
using WirtualnyDziekanat.Infrastructure.Services;

namespace WirtualnyDziekanat.WebUI.Api
{
    [Route("[controller]")]
    public class InformationsController : Controller
    {
        private readonly IInformationService _informationService;

        public InformationsController(IInformationService informationService)
        {
            _informationService = informationService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string name)
        {
            var informations = await _informationService.BrowseAsync(name);

            return Json(informations);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateInformation command)
        {
            command.InfoId = Guid.NewGuid();
            await _informationService.CreateAsync(command.InfoId, command.Title, command.Contents, command.IsActive, command.PriorityStatus);

            return Created($"/informations/{command.InfoId}", null);
        }
    }
}

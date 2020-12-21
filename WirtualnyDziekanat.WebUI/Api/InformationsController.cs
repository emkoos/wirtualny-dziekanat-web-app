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

        [HttpGet("{informationId}")]
        public async Task<IActionResult> Get(Guid informationId)
        {
            var information = await _informationService.GetAsync(informationId);
            if (information == null)
            {
                return NotFound();
            }

            return Json(information);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateInformation command)
        {
            command.InfoId = Guid.NewGuid();
            await _informationService.CreateAsync(command.InfoId, command.Title, command.Contents, command.IsActive, command.PriorityStatus);

            // Code 201
            return Created($"/informations/{command.InfoId}", null);
        }

        [HttpPut("{informationId}")]
        public async Task<IActionResult> Put(Guid informationId, [FromBody]UpdateInformation command)
        {
            await _informationService.UpdateAsync(informationId, command.Title, command.Contents, command.IsActive);

            // Code 204
            return NoContent();
        }

        [HttpDelete("{informationId}")]
        public async Task<IActionResult> Delete(Guid informationId)
        {
            await _informationService.DeleteAsync(informationId);

            // Code 204
            return NoContent();
        }
    }
}

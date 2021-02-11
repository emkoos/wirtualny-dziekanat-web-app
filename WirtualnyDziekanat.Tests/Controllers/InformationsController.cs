using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AutoMoq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using WirtualnyDziekanat.Application.DTO;
using WirtualnyDziekanat.Domain.Entities;
using WirtualnyDziekanat.Infrastructure.Services;
using WirtualnyDziekanat.WebUI.Api;

namespace WirtualnyDziekanat.Tests.Controllers
{
    [TestFixture]
    public class InformationsController
    {
        private readonly AutoMoqer autoMoqer;
        private readonly WebUI.Api.InformationsController informations;

        public InformationsController()
        {
            autoMoqer = new AutoMoqer();
            informations = autoMoqer.Create<WebUI.Api.InformationsController>();
            var info = new InformationDTO
            {
                Title = "test",
                Contents = "test test test"
            };
        }

        [Test]
        public async Task Get_When_Receives_Name_Calling_BrowseAsync_And_Return_JsonResult()
        {
            // arrange
            var moq = autoMoqer.GetMock<IInformationService>();

            // act
            var result = await informations.Get("Testing");

            // assert
            Assert.IsInstanceOf<JsonResult>(result);
            Assert.IsInstanceOf<IActionResult>(result);

            moq.Verify(v => v.BrowseAsync(It.IsAny<String>()), Times.Once);
        }

    }
}

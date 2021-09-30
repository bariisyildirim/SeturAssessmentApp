using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Setur.APIApp;
using Setur.APIApp.Controllers;
using Setur.Business.Services;
using Setur.Data.Models;
using Setur.Data.Repositories;
using Setur.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Setur.xUnitTest
{
    public class PersonControllerTest
    {
        
        private readonly IPersonService _service;

        public PersonControllerTest()
        {
            _service = new PersonService(new PersonRepository(new PersonDatabaseSettings()
            { ConnectionString = "mongodb://localhost:27017", DatabaseName = "PersonDb", PeopleCollectionName = "People" }));
        }

        [Fact]
        public void Get_Person_NotNull()
        {
            var controller = new PersonController(_service);
            var result = controller.Index();

            Assert.NotNull(result);
        }

        [Fact]
        public void Get_Person_ReturnsOkResult()
        {
            //Arrang
            var controller = new PersonController(_service);
            //Act
            var result = controller.Index();
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Get_PersonId_NotNull()
        {
            var controller = new PersonController(_service);
            var result = controller.GetWithId("614f07e3a0f61d01d9348415");

            Assert.NotNull(result);

        }

        [Fact]
        public void Get_PersonId_ReturnsNotFoundResult()
        {
            var controller = new PersonController(_service);
            var result = controller.GetWithId("614f07e3a0f61d01d9348455");
            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void Post_Person_ReturnsOkResult()
        {
            //Arrang
            var controller = new PersonController(_service);
            //Act
            var result = controller.Create(new Setur.Entity.Models.Person() { Name = "Barış", Surname = "Yıldırım", Company = "ASYNC" });
            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void Post_Person_NotNull()
        {
            var controller = new PersonController(_service);
            var result = controller.Create(new Setur.Entity.Models.Person() { Name = "Barış", Surname = "Yıldırım", Company = "ASYNC" });

            Assert.NotNull(result);
        }

        [Fact]
        public void Put_Person_NotNull()
        {
            var controller = new PersonController(_service);
            var result = controller.Update(new Setur.Entity.Models.Person()
            { Id = "614f07e3a0f61d01d9348415", Name = "Barış", Surname = "Yıldırım", Company = "ASYNC" });

            Assert.NotNull(result);
        }

        [Fact]
        public void Put_Person_ReturnsOkResult()
        {
            //Arrang
            var controller = new PersonController(_service);
            //Act
            var result = controller.Update(new Setur.Entity.Models.Person() { Name = "Barış", Surname = "Yıldırım", Company = "ASYNC" });
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Delete_Person_NotNull()
        {
            var controller = new PersonController(_service);
            var result = controller.Delete("614f07e3a0f61d01d9348415");

            Assert.NotNull(result);
        }

        [Fact]
        public void Delete_Person_ReturnsOkResult()
        {
            var controller = new PersonController(_service);
            var result = controller.Delete("614f07e3a0f61d01d9348455");

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Post_PhoneInfo_NotNull()
        {
            var controller = new PersonController(_service);
            var result = controller.InsertPhoneInfo("615085bb164bc556e5055969", new Setur.Entity.Models.Contact()
            {
                Content = "Adana",
                Type = Setur.Entity.Models.Enums.InformationType.Location
            });

            Assert.NotNull(result);
        }

        [Fact]
        public void Post_PhoneInfo_ReturnsOkResult()
        {
            var controller = new PersonController(_service);
            var result = controller.InsertPhoneInfo("615085bb164bc556e5055969", new Setur.Entity.Models.Contact()
            {
                Content = "Adana",
                Type = Setur.Entity.Models.Enums.InformationType.Location
            });

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void Delete_PhoneInfo_NotNull()
        {
            var controller = new PersonController(_service);
            var result = controller.DeletePhoneInfo("615085dc164bc556e505596a", new Setur.Entity.Models.Contact()
            {
                Content = "Adana",
                Type = Setur.Entity.Models.Enums.InformationType.Location
            });

            Assert.NotNull(result);
        }

        [Fact]
        public void Delete_PhoneInfo_ReturnsOkResult()
        {
            var controller = new PersonController(_service);
            var result = controller.DeletePhoneInfo("615085bb164bc556e5055969", new Setur.Entity.Models.Contact()
            {
                Content = "Adana",
                Type = Setur.Entity.Models.Enums.InformationType.Location
            });

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void Get_Report_NotNull()
        {
            var controller = new PersonController(_service);
            var result = controller.Report();

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Get_Report_ReturnsOkResult()
        {
            var controller = new PersonController(_service);
            var result = controller.Report();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}

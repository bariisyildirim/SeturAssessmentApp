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
        public void GetAllPersonTest()
        {
            var controller = new PersonController(_service);
            var result = controller.Index();

            Assert.NotNull(result);

        }

        [Fact]
        public void Get_Return_OkResult()
        {
            //Arrang
            var controller = new PersonController(_service);

            //Act
            var result = controller.Create(new Setur.Entity.Models.Person() { Name = "Barış", Surname = "Yıldırım", Company = "ASYNC" });

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetWithIdTest()
        {
            var controller = new PersonController(_service);
            var result = controller.GetWithId("614f07e3a0f61d01d9348415");

            Assert.NotNull(result);

        }

        [Fact]
        public void GetWithId_ReturnsNotFoundResult()
        {
            var controller = new PersonController(_service);
            var result = controller.GetWithId("614f07e3a0f61d01d9348455");
            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void CreateTest()
        {
            var controller = new PersonController(_service);
            var result = controller.Create(new Setur.Entity.Models.Person() { Name = "Barış", Surname = "Yıldırım", Company = "ASYNC" });

            Assert.NotNull(result);

        }

        [Fact]
        public  void CreateTest_Return_OkResult()
        {
            //Arrang
            var controller = new PersonController(_service); 

            //Act
            var result = controller.Create(new Setur.Entity.Models.Person() { Name = "Barış", Surname = "Yıldırım", Company = "ASYNC" });

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void UpdateTest()
        {
            var controller = new PersonController(_service);
            var result = controller.Update(new Setur.Entity.Models.Person()
            { Id = "614f07e3a0f61d01d9348415", Name = "Barış", Surname = "Yıldırım", Company = "ASYNC" });

            Assert.NotNull(result);

        }

        [Fact]
        public void DeleteTest()
        {
            var controller = new PersonController(_service);
            var result = controller.Delete("614f07e3a0f61d01d9348415");

            Assert.NotNull(result);

        }

        [Fact]
        public void InsertPhoneInfoTest()
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
        public void DeletePhoneInfoTest()
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
        public void ReportTest()
        {
            var controller = new PersonController(_service);
            var result = controller.Report();

            Assert.NotNull(result);

        }
    }
}

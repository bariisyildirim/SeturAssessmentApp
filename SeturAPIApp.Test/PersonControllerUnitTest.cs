using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Setur.APIApp;
using Setur.APIApp.Controllers;
using Setur.Business.Services;
using Setur.Data.Models;
using Setur.Data.Repositories;
using System;
using Xunit;

namespace SeturAPIApp.Test
{
    public class PersonControllerUnitTest
    {
        private readonly IPersonService _service;

        public PersonControllerUnitTest()
        {
            _service = new PersonService(new PersonRepository(new PersonDatabaseSettings()
            { ConnectionString = "mongodb://localhost:27017", DatabaseName = "PersonDb", PeopleCollectionName = "People" }));
        }
        
        [Fact]
        public void GetAllPersonTest()
        {
            var controller = new PersonController(_service,null);
            var result= controller.Index();

            Assert.IsType<OkObjectResult>(result);

        }

        [Fact]
        public void GetWithIdTest()
        {
            var controller = new PersonController(_service, null);
            var result = controller.GetWithId("614f07e3a0f61d01d9348415");

            Assert.IsType<OkObjectResult>(result);

        }

        [Fact]
        public void PersonCreateTest()
        {
            var controller = new PersonController(_service, null);
            var result = controller.Create(new Setur.Entity.Models.Person() { Name="Barış",Surname="Yıldırım", Company="ASYNC"});

            Assert.IsType<OkObjectResult>(result);

        }

        [Fact]
        public void InsertPhoneInfoTest()
        {
            var controller = new PersonController(_service, null);
            var result = controller.InsertPhoneInfo("615085bb164bc556e5055969", new Setur.Entity.Models.Contact() { 
               Content="Adana",Type=Setur.Entity.Models.Enums.InformationType.Location });

            Assert.IsType<OkObjectResult>(result);

        }

        [Fact]
        public void DeletePhoneInfoTest()
        {
            var controller = new PersonController(_service, null);
            var result = controller.DeletePhoneInfo("615085dc164bc556e505596a", new Setur.Entity.Models.Contact()
            {
                Content = "Adana",
                Type = Setur.Entity.Models.Enums.InformationType.Location
            });

            Assert.IsType<OkObjectResult>(result);
        }


        [Fact]
        public void UpdateTest()
        {
            var controller = new PersonController(_service, null);
            var result = controller.Update(new Setur.Entity.Models.Person() 
            { Id = "614f07e3a0f61d01d9348415", Name = "Barış", Surname = "Yıldırım", Company = "ASYNC" });

            Assert.IsType<OkObjectResult>(result);

        }

        [Fact]
        public void DeleteTest()
        {
            var controller = new PersonController(_service, null);
            var result = controller.Delete("614f07e3a0f61d01d9348415");

            Assert.IsType<OkObjectResult>(result);

        }
        [Fact]
        public void StartupTest()
        {
            var webHost = Microsoft.AspNetCore.WebHost.CreateDefaultBuilder().UseStartup<Startup>().Build();
            Assert.NotNull(webHost);
            Assert.NotNull(webHost.Services.GetRequiredService<IPersonService>());
            Assert.NotNull(webHost.Services.GetRequiredService<IPersonRepository>());
            Assert.NotNull(webHost.Services.GetRequiredService<IPersonDatabaseSettings>());

        }
    }
}

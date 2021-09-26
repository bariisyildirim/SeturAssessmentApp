﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Setur.Business.Services;
using Setur.Entity.Models;
using Setur.Entity.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Setur.APIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : Controller
    {
        private IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        // GET: PersonController
        [HttpGet]
        public ActionResult Index()
        {
            var data = _personService.Get();
            return Json(data);
        }

        // GET: PersonController/id
        [Route("GetWithId")]
        [HttpGet]
        public ActionResult GetWithId([FromQuery] string id)
        {
            var data = _personService.Get(id);
            return Json(data);
        }

        // POST: PersonController/Create
        [Route("Create")]
        [HttpPost]
        public ActionResult<Person> Create(Person person)
        {
            var data = _personService.Create(person);
            return Json(data);
        }
        
        // POST: PersonController/InsertPhoneInfo
        [Route("InsertPhoneInfo")]
        [HttpPost]
        public ActionResult<Person> InsertPhoneInfo([FromHeader]string id, [FromBody] Contact contact)
        {
            var data = _personService.AddContact(id, contact);

            return Json(data);
        }

        
        // DELETE: PersonController/DeletePhoneInfo
        [Route("DeletePhoneInfo")]
        [HttpPost]
        public ActionResult<Person> DeletePhoneInfo([FromHeader] string id, [FromBody] Contact contact)
        {
            var data = _personService.RemoveContact(id, contact);

            return Json(data);
        }
        

        // PUT: PersonController/id
        [Route("Update")]
        [HttpPut]
        public ActionResult Update([FromBody] Person person)
        {
            _personService.Update(person);
            return Json(true);
        }

        // DELETE: PersonController/Delete/id
        [Route("Delete")]
        [HttpDelete]

        public ActionResult Delete([FromHeader] string id)
        {
            _personService.Remove(id);
            return Json(true);
        }

        [Route("Report")]
        [HttpGet]

        public ActionResult Report()
        {
            return Json(_personService.Report());
        }

    }
}

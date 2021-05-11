using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using PeopleAccountApp.DataContracts;


namespace PeopleAcoountApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly PeopleDb db;
        public PeopleController(PeopleDb db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult GetPeople()
        {
            return Ok(db.Person);
        }
        [HttpPost]
        public IActionResult AddPerson([FromBody] Person person)
        {
            db.AddPerson(person);
            return Ok();
        }
        [HttpGet("{id}/photo")]
        public IActionResult GetPhoto([FromRoute] int id)
        {
            var p = db.Person.First(w => w.Id == id);
            return base.File(Convert.FromBase64String(p.Photo), "image/jpeg");
        }
    }

}

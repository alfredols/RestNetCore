using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestNetCore.Model;
using RestNetCore.Business;
using RestNetCore.Data.VO;
using Microsoft.AspNetCore.Authorization;

namespace RestNetCore.Controllers
{

    [ApiVersion("2")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonController : ControllerBase
    {        

        private readonly ILogger<PersonController> _logger;
        private IPersonBusiness _personBusiness;

        public PersonController(ILogger<PersonController> logger, IPersonBusiness personBusiness)
        {
            _logger = logger;
            _personBusiness = personBusiness;
        }

        [HttpGet]
        [ProducesResponseType((200),Type = typeof(List<PersonVO>))]
        [ProducesResponseType((204), Type = typeof(List<PersonVO>))]
        [ProducesResponseType((400), Type = typeof(List<PersonVO>))]
        [ProducesResponseType((401), Type = typeof(List<PersonVO>))]
        [Authorize("Bearer")]
        public IActionResult Get() {            
            return Ok(_personBusiness.FindAll());
        }

        [HttpGet("{id}")]        
        [ProducesResponseType((200), Type = typeof(PersonVO))]
        [ProducesResponseType((204), Type = typeof(PersonVO))]
        [ProducesResponseType((400), Type = typeof(PersonVO))]
        [ProducesResponseType((401), Type = typeof(PersonVO))]
        public IActionResult Get(long id)
        
        {
            var person = _personBusiness.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(PersonVO))]        
        [ProducesResponseType((400), Type = typeof(PersonVO))]
        [ProducesResponseType((401), Type = typeof(PersonVO))]
        public IActionResult Post([FromBody] PersonVO person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(_personBusiness.Create(person));
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(PersonVO))]        
        [ProducesResponseType((400), Type = typeof(PersonVO))]
        [ProducesResponseType((401), Type = typeof(PersonVO))]
        public IActionResult Put([FromBody] PersonVO person)
        {
            if (person == null) return BadRequest();
            var updatePerson = _personBusiness.Update(person);
            if (updatePerson == null) return NoContent();
            return new ObjectResult(_personBusiness);
        }

        [HttpDelete("{id}")]        
        [ProducesResponseType((204), Type = typeof(PersonVO))]
        [ProducesResponseType((400), Type = typeof(PersonVO))]
        [ProducesResponseType((401), Type = typeof(PersonVO))]
        public IActionResult Delete(long id)
        {
            var person = _personBusiness.FindById(5);
            if (person == null) return NotFound();
            return NoContent();
        }
    }
}

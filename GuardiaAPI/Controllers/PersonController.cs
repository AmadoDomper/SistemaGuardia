using AutoMapper;
using GuardiaAPI.DTOs;
using GuardiaAPI.Entities;
using GuardiaAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GuardiaAPI.Controllers
{
    [Route("api/person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IRepository<Person, int> _repository;
        private readonly IMapper mapper;

        public PersonController(IRepository<Person, int> repository, IMapper mapper)
        {
            _repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<PersonDTO>> Get()
        {
            var people = _repository.GetAll();
            return Ok(mapper.Map<List<PersonDTO>>(people));
        }

        [HttpGet("{id:int}", Name = "getPerson")]
        public ActionResult<PersonDTO> Get(int id)
        {
            var person = _repository.GetById(id);

            if (person.SedeId == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<PersonDTO>(person));

        }

        [HttpPost]
        public ActionResult Post(PersonCreationDTO personCreationDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var person = mapper.Map<Person>(personCreationDTO);
            var newPerson = mapper.Map<PersonDTO>(_repository.Insert(person));

            return CreatedAtAction(nameof(Get), new { personId = newPerson.PersonId }, newPerson);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(PersonCreationDTO personCreationDTO, int id)
        {
            var existingPerson = _repository.GetById(id);

            if (existingPerson.PersonId == null)
            {
                return NotFound();
            }

            var person = mapper.Map<Person>(personCreationDTO);
            _repository.Update(person, id);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var existingPerson = _repository.GetById(id);

            if (existingPerson.PersonId == null)
            {
                return NotFound();
            }

            _repository.Delete(id);
            return NoContent();
        }

    }

}

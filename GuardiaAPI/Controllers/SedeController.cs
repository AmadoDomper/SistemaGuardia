using AutoMapper;
using GuardiaAPI.DTOs;
using GuardiaAPI.Entities;
using GuardiaAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GuardiaAPI.Controllers
{
    [Route("api/sede")]
    [ApiController]
    public class SedeController : ControllerBase
    {
        private readonly IRepository<Sede, int> _repository;
        private readonly IMapper mapper;
        public SedeController(IRepository<Sede, int> repository, IMapper mapper)
        {
            _repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<SedeDTO>> Get()
        {
            var sedes = _repository.GetAll();
            return Ok(mapper.Map<List<SedeDTO>>(sedes));
        }

        [HttpGet("{id:int}", Name = "getSede")]
        public ActionResult<SedeDTO> Get(int id)
        {
            var sede = _repository.GetById(id);

            if (sede == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<SedeDTO>(sede));
        }

        [HttpPost]
        public ActionResult Post(SedeCreationDTO sedeCreationDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sede = mapper.Map<Sede>(sedeCreationDTO);
            var newSede = mapper.Map<SedeDTO>(_repository.Insert(sede));

            return CreatedAtAction(nameof(Get), new { sedeId = newSede.SedeId }, newSede);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(SedeCreationDTO sedeCreationDTO, int id)
        {
            var existingSede = _repository.GetById(id);

            if (existingSede == null)
            {
                return NotFound();
            }

            var sede = mapper.Map<Sede>(sedeCreationDTO);
            _repository.Update(sede, id);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var existingSede = _repository.GetById(id);

            if (existingSede == null)
            {
                return NotFound();
            }

            _repository.Delete(id);
            return NoContent();
        }
    }
}

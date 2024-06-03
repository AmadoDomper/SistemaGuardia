using AutoMapper;
using GuardiaAPI.DTOs;
using GuardiaAPI.Entities;
using GuardiaAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GuardiaAPI.Controllers
{
    [Route("api/guardDuty")]
    [ApiController]
    public class GuardDutyController : ControllerBase
    {
        private readonly IRepository<GuardDuty, int> _guardDutyRepository;
        private readonly IMapper mapper;

        public GuardDutyController(IRepository<GuardDuty, int> repository, IMapper mapper)
        {
            _guardDutyRepository = repository;
            this.mapper = mapper;
        }


        [HttpGet]
        public ActionResult<List<GuardDutyDTO>> Get()
        {
            var guards = _guardDutyRepository.GetAll();
            return Ok(mapper.Map<List<GuardDutyDTO>>(guards));
        }

        [HttpGet("{id:int}", Name = "getGuardDuty")]
        public ActionResult<GuardDutyDTO> Get(int id)
        {
            var guardDuty = _guardDutyRepository.GetById(id);

            if (guardDuty.GuardDutyId == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<GuardDutyDTO>(guardDuty));

        }

        [HttpPost]
        public ActionResult Post(GuardDutyCreationDTO guardDutyCreationDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var guardDuty = mapper.Map<GuardDuty>(guardDutyCreationDTO);
            var newGuardDuty = mapper.Map<GuardDutyDTO>(_guardDutyRepository.Insert(guardDuty));

            return CreatedAtAction(nameof(Get), new { guardDutyId = newGuardDuty.GuardDutyId }, newGuardDuty);
        }
        
        [HttpPut("{id:int}")]
        public ActionResult Put(GuardDutyCreationDTO guardDutyCreationDTO, int id)
        {
            var existingGuardDuty = _guardDutyRepository.GetById(id);

            if (existingGuardDuty.PersonId == null)
            {
                return NotFound();
            }

            var guardDuty = mapper.Map<GuardDuty>(guardDutyCreationDTO);
            _guardDutyRepository.Update(guardDuty, id);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var existingGuardDuty = _guardDutyRepository.GetById(id);

            if (existingGuardDuty.GuardDutyId == null)
            {
                return NotFound();
            }

            _guardDutyRepository.Delete(id);
            return NoContent();
        }
    }
}

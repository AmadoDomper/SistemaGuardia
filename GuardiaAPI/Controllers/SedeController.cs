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
    }
}

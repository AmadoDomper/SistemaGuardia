using AutoMapper;
using GuardiaAPI.DTOs;
using GuardiaAPI.Entities;
using GuardiaAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GuardiaAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepository<User, int> _repository;
        private readonly IMapper mapper;
        public UserController(IRepository<User, int> repository, IMapper mapper)
        {
            _repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<UserDTO>> Get()
        {
            var users = _repository.GetAll();
            return Ok(mapper.Map<List<UserDTO>>(users));
        }

        [HttpGet("{id:int}", Name = "getUser")]
        public ActionResult<UserDTO> Get(int id)
        {
            var user = _repository.GetById(id);

            if (user.UserId == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<UserDTO>(user));
        }

        [HttpPost]
        public ActionResult Post(UserCreationDTO userCreationDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = mapper.Map<User>(userCreationDTO);
            var newUser = mapper.Map<UserDTO>(_repository.Insert(user));

            return CreatedAtAction(nameof(Get), new { userId = newUser.UserId }, newUser);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(UserCreationDTO userCreationDTO, int id)
        {
            var existingUser = _repository.GetById(id);

            if (existingUser.UserId == null)
            {
                return NotFound();
            }

            var user = mapper.Map<User>(userCreationDTO);
            _repository.Update(user, id);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var existingUser = _repository.GetById(id);

            if (existingUser.UserId == null)
            {
                return NotFound();
            }

            _repository.Delete(id);
            return NoContent();
        }
    }
}

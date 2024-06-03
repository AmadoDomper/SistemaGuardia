using AutoMapper;
using GuardiaAPI.DTOs;
using GuardiaAPI.Entities;
using GuardiaAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GuardiaAPI.Controllers
{
    [Route("api/attendance")]
    [ApiController]
    public class AttendanceController : Controller
    {
        private readonly IRepository<Attendance,int> _attendanceRepository;
        private readonly IMapper mapper;

        public AttendanceController(IRepository<Attendance, int> attendanceRepository, IMapper mapper)
        {
            _attendanceRepository = attendanceRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<AttendanceDTO>> Get()
        {
            var attendances = _attendanceRepository.GetAll();
            return Ok(mapper.Map<List<AttendanceDTO>>(attendances));
        }

        [HttpGet("{id:int}", Name = "getAttendance")]
        public ActionResult<AttendanceDTO> Get(int id)
        {
            var attendance = _attendanceRepository.GetById(id);

            if (attendance.AttendanceId == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<AttendanceDTO>(attendance));

        }

        [HttpPost]
        public ActionResult Post(AttendanceCreationDTO attendanceCreationDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var attendance = mapper.Map<Attendance>(attendanceCreationDTO);
            var newAttendance = mapper.Map<AttendanceDTO>(_attendanceRepository.Insert(attendance));

            return CreatedAtAction(nameof(Get), new { attendanceId = newAttendance.AttendanceId }, newAttendance);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(AttendanceCreationDTO attendanceCreationDTO, int id)
        {
            var existingAttendance = _attendanceRepository.GetById(id);

            if (existingAttendance.AttendanceId == null)
            {
                return NotFound();
            }

            var attendance = mapper.Map<Attendance>(attendanceCreationDTO);
            _attendanceRepository.Update(attendance, id);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var existingAttendance = _attendanceRepository.GetById(id);

            if (existingAttendance.AttendanceId == null)
            {
                return NotFound();
            }

            _attendanceRepository.Delete(id);
            return NoContent();
        }
    }
}

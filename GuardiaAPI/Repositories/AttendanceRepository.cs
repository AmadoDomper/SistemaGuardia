using Dapper;
using GuardiaAPI.Entities;
using Microsoft.Extensions.Options;
using MySqlConnector;
using System.Data;

namespace GuardiaAPI.Repositories
{
    public class AttendanceRepository : IRepository<Attendance, int>
    {
        private readonly IDbConnection _db;

        public AttendanceRepository(IOptions<ConnectionStringList> connectionStringList)
        {
            _db = new MySqlConnection(connectionStringList.Value.Default);
        }
        public void Dispose()
        {
            _db.Close();
        }
        public void Delete(int attendanceId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("_AttendanceId", attendanceId);
            _db.Execute("DeleteAttendance", parameters, commandType:CommandType.StoredProcedure);
        }
        public List<Attendance> GetAll()
        {
            return _db.Query<Attendance>("GetAllAttendance", commandType:CommandType.StoredProcedure).ToList();
        }
        public Attendance GetById(int attendanceId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("_AttendanceId", attendanceId);
            return _db.Query<Attendance>("GetAttendanceById",parameters, commandType:CommandType.StoredProcedure).FirstOrDefault();
        }
        public Attendance Insert(Attendance entity)
        {
            var parameters = new DynamicParameters();
            parameters.Add("_PersonId", entity.PersonId);
            parameters.Add("_UserId", entity.UserId);
            parameters.Add("_GuardDutyId", entity.GuardDutyId);
            parameters.Add("_DateIn", entity.DateIn);
            parameters.Add("_DateOut", entity.DateOut);
            parameters.Add("_Status", entity.Status);

            var attendanceId = _db.Query<int>("AddNewAttendance",parameters, commandType:CommandType.StoredProcedure).Single();
            entity.AttendanceId = attendanceId;
            return entity;
        }
        public void Update(Attendance entity, int attendanceId)
        {
            entity.AttendanceId = attendanceId;
            var parameters = new DynamicParameters();
            parameters.Add("_AttendanceId", entity.AttendanceId);
            parameters.Add("_PersonId", entity.PersonId);
            parameters.Add("_UserId", entity.UserId);
            parameters.Add("_GuardDutyId", entity.GuardDutyId);
            parameters.Add("_DateIn", entity.DateIn);
            parameters.Add("_DateOut", entity.DateOut);
            parameters.Add("_Status", entity.Status);

            _db.Query<int>("UpdateAttendance", parameters, commandType: CommandType.StoredProcedure);
            
        }
    }
}

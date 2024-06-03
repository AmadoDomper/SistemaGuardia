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
            _db.Execute("DELETE FROM attendance WHERE AttendanceId = @AttendanceId", new { attendanceId });
        }
        public List<Attendance> GetAll()
        {
            return _db.Query<Attendance>("SELECT * FROM attendance").ToList();
        }
        public Attendance GetById(int attendanceId)
        {
            return _db.Query<Attendance>("SELECT * FROM attendance WHERE AttendanceId = @AttendanceId", new { attendanceId }).FirstOrDefault(new Attendance());
        }
        public Attendance Insert(Attendance entity)
        {
            var sql = @"INSERT INTO attendance 
                        (
                        PersonId,
                        UserId,
                        GuardDutyId,
                        DateIn,
                        DateOut,
                        Status 		
                        )
                         VALUES              
                        (
                        @PersonId,
                        @UserId,
                        @GuardDutyId,
                        @DateIn,
                        @DateOut,
                        @Status 
                        );

                        SELECT LAST_INSERT_ID();";

            var attendanceId = _db.Query<int>(sql, entity).Single();
            entity.AttendanceId = attendanceId;
            return entity;
        }
        public void Update(Attendance entity, int attendanceId)
        {
            var sql = @"UPDATE attendance SET 
                        PersonId=@PersonId,
                        UserId=@UserId,
                        GuardDutyId=@GuardDutyId,
                        DateIn=@DateIn,
                        DateOut=@DateOut,
                        Status=@Status


                        WHERE AttendanceId = @AttendanceId";

            _db.Execute(sql, new
            {
                entity.PersonId,
                entity.UserId,
                entity.GuardDutyId,
                entity.DateIn,
                entity.DateOut,
                entity.Status,
                AttendanceId = attendanceId
            });
        }
    }
}

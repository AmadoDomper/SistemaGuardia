using Dapper;
using GuardiaAPI.Entities;
using Microsoft.Extensions.Options;
using MySqlConnector;
using System.Data;

namespace GuardiaAPI.Repositories
{
    public class GuardDutyRepository : IRepository<GuardDuty, int>
    {
        private readonly IDbConnection _db;

        public GuardDutyRepository(IOptions<ConnectionStringList> connectionStrings)
        {
            _db = new MySqlConnection(connectionStrings.Value.Default);
        }
        public void Dispose()
        {
            _db.Close();
        }

        public void Delete(int guardDutyId)
        {
            _db.Execute("DELETE FROM guardDuty WHERE GuardDutyId = @GuardDutyId", new { guardDutyId });
        }

        public List<GuardDuty> GetAll()
        {
            return _db.Query<GuardDuty>("SELECT * FROM guardDuty").ToList();
        }

        public GuardDuty GetById(int guardDutyId)
        {
            return _db.Query<GuardDuty>("SELECT * FROM guardDuty WHERE GuardDutyId = @GuardDutyId", new { guardDutyId }).FirstOrDefault(new GuardDuty());
        }

        public GuardDuty Insert(GuardDuty entity)
        {
            var sql = @"INSERT INTO guardDuty 
                        (PersonId,
                         UserId,
                         DateIn,
                         DateOut,
                         Status)
                         VALUES              
                        (@PersonId,
                         @UserId,
                         @DateIn,
                         @DateOut,
                         @Status);

                        SELECT LAST_INSERT_ID();";

            var guardDutyId = _db.Query<int>(sql, entity).Single();
            entity.GuardDutyId = guardDutyId;
            return entity;
        }

        public void Update(GuardDuty entity, int guardDutyId)
        {
            var sql = @"UPDATE guardDuty SET 
                        PersonId=@PersonId,
                        UserId=@UserId,
                        DateIn=@DateIn,
                        DateOut=@DateOut,
                        Status=@Status
                        WHERE GuardDutyId = @GuardDutyId";

            _db.Execute(sql, new
            {
                entity.PersonId,
                entity.UserId,
                entity.DateIn,
                entity.DateOut,
                entity.Status,
                GuardDutyId = guardDutyId
            });
        }
    }
}

using AutoMapper.Configuration.Annotations;
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
            var parameters = new DynamicParameters();
            parameters.Add("_GuardDutyId", guardDutyId);
            _db.Execute("DeleteGuardDuty", parameters, commandType:CommandType.StoredProcedure);
        }

        public List<GuardDuty> GetAll()
        {
            return _db.Query<GuardDuty>("GetAllGuardDuty", commandType:CommandType.StoredProcedure).ToList();
        }

        public GuardDuty GetById(int guardDutyId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("_GuardDutyId", guardDutyId);
            return _db.Query<GuardDuty>("GetGuardDutyById", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public GuardDuty Insert(GuardDuty entity)
        {
            var parameters = new DynamicParameters();
            parameters.Add("_PersonId", entity.PersonId);
            parameters.Add("_UserId", entity.UserId);
            parameters.Add("_DateIn", entity.DateIn);
            parameters.Add("_DateOut", entity.DateOut);
            parameters.Add("_Status", entity.Status);


            var guardDutyId = _db.Query<int>("AddNewGuardDuty", parameters, commandType: CommandType.StoredProcedure).Single();
            entity.GuardDutyId = guardDutyId;
            return entity;
        }

        public void Update(GuardDuty entity, int guardDutyId)
        {
            entity.GuardDutyId = guardDutyId;
            var parameters = new DynamicParameters();
            parameters.Add("_GuardDutyId", entity.GuardDutyId);
            parameters.Add("_PersonId", entity.PersonId);
            parameters.Add("_UserId", entity.UserId);
            parameters.Add("_DateIn", entity.DateIn);
            parameters.Add("_DateOut", entity.DateOut);
            parameters.Add("_Status", entity.Status);


            _db.Query<int>("UpdateGuardDuty", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}

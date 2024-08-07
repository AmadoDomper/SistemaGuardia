using Dapper;
using GuardiaAPI.Entities;
using Microsoft.Extensions.Options;
using MySqlConnector;
using System.Data;

namespace GuardiaAPI.Repositories
{
    public class UserProvider : IRepository<User, int>
    {
        private readonly IDbConnection _db;

        public UserProvider(IOptions<ConnectionStringList> connectionStrings)
        {
            _db = new MySqlConnection(connectionStrings.Value.Default);
        }
        public void Dispose()
        {
            _db.Close();
        }

        public void Delete(int userId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("_UserId", userId);
            _db.Execute("DeleteUsuario", parameters, commandType:CommandType.StoredProcedure);
            
        }

        public List<User> GetAll()
        {
            return _db.Query<User>("GetAllUsuario", commandType:CommandType.StoredProcedure).ToList();
        }

        public User GetById(int userId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("_UserId", userId);
            return _db.Query<User>("GetUsuarioByID", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public User Insert(User entity)
        {

            var parameters = new DynamicParameters();
            parameters.Add("_UserName", entity.UserName);
            parameters.Add("_UserPass", entity.UserPass);
            parameters.Add("_Email", entity.Email);
            parameters.Add("_RolId", entity.RolId);
            parameters.Add("_SedeId", entity.SedeId);
            parameters.Add("_State", entity.State);

            var userId = _db.Query<int>("AddNewUsuario", parameters, commandType: CommandType.StoredProcedure).Single();
            entity.UserId = userId;
            return entity;
        }

        public void Update(User entity, int userId)
        {
            entity.UserId = userId;

            var parameters = new DynamicParameters();
            parameters.Add("_UserId", entity.UserId);
            parameters.Add("_UserName", entity.UserName);
            parameters.Add("_UserPass", entity.UserPass);
            parameters.Add("_Email", entity.Email);
            parameters.Add("_RolId", entity.RolId);
            parameters.Add("_SedeId", entity.SedeId);
            parameters.Add("_State", entity.State);

            _db.Query<int>("UpDateUsuario", parameters, commandType: CommandType.StoredProcedure);
            
        }
    }
}

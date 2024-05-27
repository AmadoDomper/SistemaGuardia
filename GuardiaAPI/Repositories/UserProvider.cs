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
            _db.Execute("DELETE FROM Usuario WHERE UserId = @UserId", new { userId });
        }

        public List<User> GetAll()
        {
            return _db.Query<User>("SELECT * FROM usuario").ToList();
        }

        public User GetById(int userId)
        {
            return _db.Query<User>("SELECT * FROM Usuario WHERE UserId = @UserId", new { userId }).FirstOrDefault(new User()); ;
        }

        public User Insert(User entity)
        {
            var sql = @"INSERT INTO Usuario (UserName, UserPass, Email, RolId, SedeId, State) 
                        VALUES              (@UserName, @UserPass, @Email, @RolId, @SedeId, @State);
                        SELECT LAST_INSERT_ID();";

            var userId = _db.Query<int>(sql, entity).Single();
            entity.UserId = userId;
            return entity;
        }

        public void Update(User entity, int userId)
        {
            var sql = @"UPDATE Usuario SET 
                        UserName = @UserName, 
                        UserPass = @UserPass, 
                        Email = @Email,
                        RolId = @RolId,
                        SedeId = @SedeId,
                        State = @State
                        WHERE UserId = @UserId";

            _db.Execute(sql, new
            {
                entity.UserName,
                entity.UserPass,
                entity.Email,
                entity.RolId,
                entity.SedeId,
                entity.State,
                UserId = userId
            });
        }
    }
}

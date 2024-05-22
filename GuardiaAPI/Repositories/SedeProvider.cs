using Dapper;
using GuardiaAPI.Entities;
using Microsoft.Extensions.Options;
using MySqlConnector;
using System.Data;
using System.Linq;

namespace GuardiaAPI.Repositories
{
    public class SedeProvider : IRepository<Sede, int>
    {
        private readonly IDbConnection _db;
        public SedeProvider(IOptions<ConnectionStringList> connectionStrings)
        {
            _db = new MySqlConnection(connectionStrings.Value.Default);
        }
        public void Dispose()
        {
            _db.Close();
        }
        public void Delete(int sedeId)
        {
            _db.Execute("DELETE FROM Sede WHERE SedeId = @SedeId", new { sedeId }); ;
        }

        public List<Sede> GetAll()
        {
            return _db.Query<Sede>("SELECT * FROM sede").ToList(); ;
        }

        public Sede GetById(int sedeId)
        {
            return _db.Query<Sede>("SELECT * FROM Sede WHERE SedeId = @SedeId", new { sedeId }).FirstOrDefault(new Sede()); ;
        }

        public Sede Insert(Sede entity)
        {
            var sql = @"INSERT INTO Sede (Name, Adress, City) 
                        VALUES (@Name, @Adress, @City);
                        SELECT LAST_INSERT_ID();";

            var sedeId = _db.Query<int>(sql, entity).Single();
            entity.SedeId = sedeId;
            return entity; ;
        }

        public void Update(Sede entity, int sedeId)
        {
            var sql = @"UPDATE Sede SET 
                        Name = @Name, 
                        Adress = @Adress, 
                        City = @City
                        WHERE SedeId = @SedeId";

            _db.Execute(sql, new
            {
                entity.Name,
                entity.Adress,
                entity.City,
                SedeId = sedeId
            }); ;
        }
    }
}

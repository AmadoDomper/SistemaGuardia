using Dapper;
using GuardiaAPI.Entities;
using Microsoft.Extensions.Options;
using MySqlConnector;
using System.Data;

namespace GuardiaAPI.Repositories
{
    public class DataBaseRepository : IRepository<Contact, int>
    {
        private readonly IDbConnection _db;
        public DataBaseRepository(IOptions<ConnectionStringList> connectionStrings)
        {
            _db = new MySqlConnection(connectionStrings.Value.Default);
        }

        public void Dispose()
        {
            _db.Close();
        }

        public void Delete(int id)
        {
            _db.Execute("DELETE FROM miembro WHERE Id = @id", new { id });
        }

        public List<Contact> GetAll()
        {
            return _db.Query<Contact>("SELECT * FROM miembro").ToList();
        }

        public Contact GetById(int id)
        {
            return _db.Query<Contact>("SELECT * FROM miembro WHERE id = @id", new { id }).FirstOrDefault(new Contact());
        }

        public Contact Insert(Contact entity)
        {
            var sql = @"INSERT INTO miembro (Name, Email, Phone, Street) 
                        VALUES (@Name, @Email, @Phone, @Street);
                        SELECT LAST_INSERT_ID();";

            var id = _db.Query<int>(sql, entity).Single();
            entity.Id = id;
            return entity;
        }

        public void Update(Contact entity, int id)
        {
            var sql = @"UPDATE miembro SET 
                        Name = @Name, 
                        Email = @Email, 
                        Phone = @Phone, 
                        Street = @Street 
                        WHERE Id = @Id";

            _db.Execute(sql, new
            {
                entity.Name,
                entity.Email,
                entity.Phone,
                entity.Street,
                Id = id
            });
        }
    }
}

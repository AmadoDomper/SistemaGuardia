using Dapper;
using GuardiaAPI.Entities;
using Microsoft.Extensions.Options;
using MySqlConnector;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace GuardiaAPI.Repositories
{
    public class PersonRepositoy : IRepository<Person, int>
    {
        private readonly IDbConnection _db;

        public PersonRepositoy(IOptions<ConnectionStringList> connectionStrings)
        {
            _db = new MySqlConnection(connectionStrings.Value.Default);
        }
        public void Dispose()
        {
            _db.Close();
        }

        public void Delete(int personId)
        {
            _db.Execute("DELETE FROM Person WHERE PersonId = @PersonId", new { personId });
        }

        public List<Person> GetAll()
        {
            return _db.Query<Person>("SELECT * FROM person").ToList();
        }

        public Person GetById(int personId)
        {
            return _db.Query<Person>("SELECT * FROM Person WHERE PersonId = @PersonId", new { personId }).FirstOrDefault(new Person());
        }

        public Person Insert(Person entity)
        {
            var sql = @"INSERT INTO Person 
                        (PersonType, 
                         FirstName, 
                         LastName, 
                         Email, 
                         Phone, 
                         DocumentType, 
                         Document, 
                         PhotoUrl, 
                         SedeId, 
                         CreatedDate,
                         ModifiedDate, 
                         State) 
                        VALUES              
                        (@PersonType, 
                         @FirstName, 
                         @LastName, 
                         @Email, 
                         @Phone, 
                         @DocumentType, 
                         @Document, 
                         @PhotoUrl, 
                         @SedeId, 
                         @CreatedDate,
                         @ModifiedDate, 
                         @State);

                        SELECT LAST_INSERT_ID();";

            var personId = _db.Query<int>(sql, entity).Single();
            entity.PersonId = personId;
            return entity;
        }

        public void Update(Person entity, int personId)
        {
            var sql = @"UPDATE Person SET 
                        PersonType= @PersonType, 
                        FirstName= @FirstName, 
                        LastName= @LastName, 
                        Email= @Email, 
                        Phone= @Phone, 
                        DocumentType= @DocumentType,
                        Document= @Document, 
                        PhotoUrl= @PhotoUrl, 
                        SedeId= @SedeId, 
                        CreatedDate= @CreatedDate,
                        ModifiedDate= @ModifiedDate,
                        State= @State
                        WHERE PersonId = @PersonId";

            _db.Execute(sql, new
            {
                entity.PersonType,
                entity.FirstName,
                entity.LastName,
                entity.Email,
                entity.Phone,
                entity.DocumentType,
                entity.Document,
                entity.PhotoUrl,
                entity.SedeId,
                entity.CreatedDate,
                entity.ModifiedDate,
                entity.State,
                PersonId = personId
            }); 
        }
    }
}


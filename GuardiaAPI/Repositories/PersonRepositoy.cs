using Dapper;
using GuardiaAPI.Entities;
using Microsoft.Extensions.Options;
using MySqlConnector;
using System.Data;


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
            var parameters = new DynamicParameters();
            parameters.Add("_PersonId", personId);
            _db.Execute("DeletePerson",parameters, commandType: CommandType.StoredProcedure);
        }

        public List<Person> GetAll()
        {
            return _db.Query<Person>("GEtAllPerson", commandType: CommandType.StoredProcedure).ToList();
        }

        public Person GetById(int personId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("_PersonId", personId);
            return _db.Query<Person>("GetPersonById", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public Person Insert(Person entity)
        {
            var parameters = new DynamicParameters();
            parameters.Add("_PersonType", entity.PersonType);
            parameters.Add("_FirstName", entity.FirstName);
            parameters.Add("_LastName", entity.LastName);
            parameters.Add("_Email", entity.Email);
            parameters.Add("_Phone", entity.Phone);
            parameters.Add("_DocumentType", entity.DocumentType);
            parameters.Add("_Document", entity.Document);
            parameters.Add("_PhotoUrl", entity.PhotoUrl);
            parameters.Add("_SedeId", entity.SedeId);
            parameters.Add("_CreatedDate", entity.CreatedDate);
            parameters.Add("_ModifiedDate", entity.ModifiedDate);
            parameters.Add("_State", entity.State);

            var personId = _db.Query<int>("AddNewPerson", parameters, commandType: CommandType.StoredProcedure).Single();
            entity.PersonId = personId;
            return entity;
        }

        public void Update(Person entity, int personId)
        {
            entity.PersonId = personId;

            var parameters = new DynamicParameters();
            parameters.Add("_PersonId", entity.PersonId);
            parameters.Add("_PersonType", entity.PersonType);
            parameters.Add("_FirstName", entity.FirstName);
            parameters.Add("_LastName", entity.LastName);
            parameters.Add("_Email", entity.Email);
            parameters.Add("_Phone", entity.Phone);
            parameters.Add("_DocumentType", entity.DocumentType);
            parameters.Add("_Document", entity.Document);
            parameters.Add("_PhotoUrl", entity.PhotoUrl);
            parameters.Add("_SedeId", entity.SedeId);
            parameters.Add("_CreatedDate", entity.CreatedDate);
            parameters.Add("_ModifiedDate", entity.ModifiedDate);
            parameters.Add("_State", entity.State);

            _db.Execute("UpDAtePerson", parameters, commandType: CommandType.StoredProcedure);
            
        }
    }
}


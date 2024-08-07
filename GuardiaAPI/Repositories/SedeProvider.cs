using Dapper;
using GuardiaAPI.Entities;
using Microsoft.Extensions.Options;
using MySqlConnector;
using System.Data;

namespace GuardiaAPI.Repositories
{
    public class SedeProvider : IRepository<Sede, int>
    {
        private readonly IDbConnection _db;
        

        public SedeProvider(IOptions<ConnectionStringList> connectionStrings, IConfiguration configuration)
        {
            _db = new MySqlConnection(connectionStrings.Value.Default);
            
        }
        public void Dispose()
        {
            _db.Close();
        }
        public void Delete(int sedeId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("_SedeId",sedeId);
            _db.Execute("DeleteSede", parameters, commandType: CommandType.StoredProcedure);
        }

        public List<Sede> GetAll()
        {
            return _db.Query<Sede>("GetAllSede", commandType: CommandType.StoredProcedure).ToList();
        }

        public Sede GetById(int sedeId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("_SedeId",sedeId);
            return _db.Query<Sede>("GetSedeById", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public Sede Insert(Sede entity)
        {
            var parameters = new DynamicParameters();
            parameters.Add("_Name",entity.Name);
            parameters.Add("_Address",entity.Address);
            parameters.Add("_City",entity.City);

            
            var sedeId = _db.Query<int>("AddNewSede", parameters, commandType: CommandType.StoredProcedure).Single();
            entity.SedeId = sedeId;
            return entity; ;
        }

        public void Update(Sede entity, int sedeId)
        {
            entity.SedeId = sedeId;

            var parameters = new DynamicParameters();
            parameters.Add("_sedeId",entity.SedeId);
            parameters.Add("_Name", entity.Name);
            parameters.Add("_Address", entity.Address);
            parameters.Add("_City", entity.City);
                      
            _db.Execute("UpDateSede", parameters, commandType: CommandType.StoredProcedure);
            
            
        }
    }
}

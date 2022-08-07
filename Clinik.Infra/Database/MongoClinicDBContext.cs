using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Clinik.Infra.Database
{
    public class MongoClinicDBContext : IMongoDBContext
    {
        private IMongoDatabase _db { get; set; }
        private MongoClient _mongoClient { get; set; }
        public IClientSessionHandle Session { get; set; }
        public MongoClinicDBContext(IOptions<MongoSettings> configuration)
        {
            this._mongoClient = new MongoClient(configuration.Value.Connection);
            this._db =_mongoClient.GetDatabase(configuration.Value.DatabaseName);
        }
      
        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return this._db.GetCollection<T>(name);
        }
    }
}
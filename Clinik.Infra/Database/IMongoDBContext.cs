using MongoDB.Driver;

namespace Clinik.Infra.Database
{
    public interface IMongoDBContext
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
using MongoDB.Driver;

namespace Amg_Ingressos_aqui_authorizer_api_v2.Infra.Interfaces
{
    public interface IDbConnection
    {
        IMongoCollection<T> GetConnection<T>();
        MongoClient GetClient();
    }
}
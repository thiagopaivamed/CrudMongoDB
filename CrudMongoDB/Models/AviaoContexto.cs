using CrudMongoDB.Config;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudMongoDB.Models
{
    public class AviaoContexto
    {
        private readonly IMongoDatabase _mongoDatabase;

        public AviaoContexto(IOptions<ConfigDB> opcoes)
        {
            MongoClient mongoClient = new MongoClient(opcoes.Value.ConnectionString);

            if(mongoClient != null)
            {
                _mongoDatabase = mongoClient.GetDatabase(opcoes.Value.Database);
            }
        }

        public IMongoCollection<Aviao> Avioes
        {
            get
            {
                return _mongoDatabase.GetCollection<Aviao>("Avioes");
            }
        }
    }
}

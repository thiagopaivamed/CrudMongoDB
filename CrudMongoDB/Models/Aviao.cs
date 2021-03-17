using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudMongoDB.Models
{
    public class Aviao
    {
        [BsonElement("_id")]
        public Guid AviaoId { get; set; }

        public string Fabricante { get; set; }

        public string Nome { get; set; }

        public int QuantidadeLugares { get; set; }
    }
}

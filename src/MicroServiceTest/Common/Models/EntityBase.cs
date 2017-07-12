using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Mmu.MicroServiceTest.Common.Models
{
    public abstract class EntityBase
    {
        protected EntityBase()
        {
            EntityTypeName = GetType().Name;
        }

        public string EntityTypeName { get; set; }

        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string Id { get; set; }
    }
}
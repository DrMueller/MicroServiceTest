using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Mmu.MicroServiceTest.Common.Models
{
    public abstract class EntityBase : IEquatable<EntityBase>
    {
        protected EntityBase(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("The ID cannot be empty.", nameof(id));
            }

            Id = id;
        }

        protected EntityBase()
        {
            EntityTypeName = GetType().Name;
        }

        public string EntityTypeName { get; set; }

        // Id needs a setter for MongoDB
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string Id { get; set; }

        public override bool Equals(object otherObject)
        {
            var entity = otherObject as EntityBase;
            if (entity != null)
            {
                return Equals(entity);
            }

            return base.Equals(otherObject);
        }

        public bool Equals(EntityBase other)
        {
            return other != null && Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
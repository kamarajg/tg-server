using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace tg_server.models
{
    [BsonIgnoreExtraElements]
    public class comment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("refId")]
        public string RefId { get; set; } = String.Empty;

        [BsonElement("Comments")]
        public string Comments { get; set; } = String.Empty;
    }
}

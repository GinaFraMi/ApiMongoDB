using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ApiCRUDMongoDB.Models;
public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    [BsonElement("email")]
    public string? Email { get; set; }
    [BsonElement("password")]
    public string? Password { get; set; }
    [BsonElement("first_name")]
    public string? FirstName { get; set; }
    [BsonElement("last_name")]
    public string? LastName { get; set; }
}
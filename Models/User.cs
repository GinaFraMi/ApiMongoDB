using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ApiCRUDMongoDB.Models;
public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("email")]
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Ivalid email")]
    public string? Email { get; set; }

    [BsonElement("password")]
    [Required(ErrorMessage = "Password is required")]
    [RegularExpression("^(?=.*[A-Z])(?=.*\\d)(?=.*[!@#$%])[A-Za-z\\d!@#$%]{8,20}$",
        ErrorMessage = "Password must be 8 to 20 characters long and include at least one uppercase letter, one number, and one special character (!@#$%).")]
    public string? Password { get; set; }

    [BsonElement("first_name")]
    [Required(ErrorMessage = "First Name is required")]
    [StringLength(30, MinimumLength = 3 , ErrorMessage =" Must have at leat 3 characters")]
    public string? FirstName { get; set; }

    [BsonElement("last_name")]
    public string? LastName { get; set; }
}
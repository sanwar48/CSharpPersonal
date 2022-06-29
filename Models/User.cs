using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Learningproject.Models
{
    [BsonIgnoreExtraElements]
    public class User
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? id { get; set; }

        [BsonElement("name")]
        [Required(ErrorMessage ="User name is required")]
        public string UserName { get; set; } = null!;

        [BsonElement("email")]
        [Required(ErrorMessage ="Email address is requires")]
        [EmailAddress(ErrorMessage ="Enter valid email address")]
        public string Email { get; set; } = null!;


        [BsonElement("password")]
        [Required(ErrorMessage ="Enter valid password")]
        public string Password { get; set; } = null!;
    }
}

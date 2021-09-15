using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GrowIndigo_Otp_Login_DemoProject.Services
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string name { get; set; }
        public string email { get; set; }

        public string phoneNumber { get; set; }
    }
}

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace GrowIndigo_Otp_Login_DemoProject
{
    public class PhoneNumber
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string phonenumber { get; set; }
        public int otp { get; set; }
    }
}

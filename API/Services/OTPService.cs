using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrowIndigo_Otp_Login_DemoProject.Services
{
    public class OTPService
    {
        private readonly IMongoCollection<PhoneNumber> _phonenumbers;

        public OTPService(IOTPDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _phonenumbers = database.GetCollection<PhoneNumber>(settings.CollectionName);
        }

        public List<PhoneNumber> Get() =>
            _phonenumbers.Find(phonenumber => true).ToList();

        public PhoneNumber Get(string phonenumber) =>
            _phonenumbers.Find<PhoneNumber>(record => record.phonenumber == phonenumber).FirstOrDefault();

        public PhoneNumber Create(PhoneNumber record)
        {
            _phonenumbers.InsertOne(record);
            return record;
        }

        public void Remove(PhoneNumber phonenumber) =>
            _phonenumbers.DeleteOne(record => record.phonenumber == phonenumber.phonenumber);

    }
}

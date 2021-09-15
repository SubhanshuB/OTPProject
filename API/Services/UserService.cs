using System;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrowIndigo_Otp_Login_DemoProject.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _user;

        public UserService(IUserDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _user = database.GetCollection<User>(settings.CollectionName);
        }

        public List<User> Get() =>
            _user.Find(users => true).ToList();

        public User Get(string phonenumber) =>
            _user.Find<User>(record => record.phoneNumber == phonenumber).FirstOrDefault();

        public User Create(User record)
        {
            try
            {
                _user.InsertOne(record);
            }
            catch (Exception)
            {
                return null;
            }
            return record;
        }

        public void Remove(string phoneNumber) =>
            _user.DeleteOne(record => record.phoneNumber == phoneNumber);
    }
}

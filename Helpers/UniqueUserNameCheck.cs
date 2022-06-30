using Learningproject.Models;
using MongoDB.Driver;

namespace Learningproject.Helpers
{
    public class UniqueUserNameCheck : IUniqueUserNameCheck
    {
        private readonly IMongoCollection<User> _userRegistrationCollections;

        public UniqueUserNameCheck(ILearningprojectDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _userRegistrationCollections = database.GetCollection<User>(settings.UsercollectionName);
        }
        public bool CheckUserName(string userName)
        {
            var filter = (Builders<User>.Filter.Eq("UserName", userName));
            User? UniqueUserName = _userRegistrationCollections.Find(filter).FirstOrDefault();

            if (UniqueUserName == null) return true;
            return false;
        }
    }
}

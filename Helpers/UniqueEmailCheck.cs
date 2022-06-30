using Learningproject.Models;
using MongoDB.Driver;

namespace Learningproject.Helpers
{
    public class UniqueEmailCheck : IUniqueEmailCheck
    {
        private readonly IMongoCollection<User> _userRegistrationCollections;

        public UniqueEmailCheck(ILearningprojectDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _userRegistrationCollections = database.GetCollection<User>(settings.UsercollectionName);
        }
        public bool CheckUserEmail(string userEmail)
        {
            var filter = (Builders<User>.Filter.Eq("Email", userEmail));
            User? UniqueEmail = _userRegistrationCollections.Find(filter).FirstOrDefault();

            if (UniqueEmail == null) return true;
            return false;
        }
    }
}

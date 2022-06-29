using Learningproject.Models;
using MongoDB.Driver;
using Microsoft.EntityFrameworkCore;

namespace Learningproject.Services
{
    public class SignupServices : ISignupServices
    {
        private readonly IMongoCollection<User> userCollectionName;

        public SignupServices(ILearningprojectDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            userCollectionName = database.GetCollection<User>(settings.UsercollectionName);
        }
        public async Task CreateAsync(User user)
        {
            await userCollectionName.InsertOneAsync(user);
        }

        public void Delete(string id)
        {
            userCollectionName.DeleteOneAsync(User => User.id == id);
        }

        public async Task<List<User>> GetAsync()
        {
           return await userCollectionName.Find(User=>true).ToListAsync();
        }

        public async Task<User> GetAsync(string id)
        {
            return await userCollectionName.Find(User => User.id == id).FirstOrDefaultAsync();
        }

        public  void Update(string id, User user)
        {
            // User? CheckUniqueness = userCollectionName.Find<User>(User => User.Email == user.Email).FirstOrDefault();
            //  if (CheckUniqueness == null) userCollectionName.ReplaceOne(User => User.id == id, user);
            // else throw new InvalidOperationException();
            userCollectionName.ReplaceOne(User => User.id == id, user);
        }
    }
}

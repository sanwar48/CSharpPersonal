using Learningproject.Models;
using MongoDB.Driver;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Learningproject.DTOs;

namespace Learningproject.Services
{
    public class SignupServices : ISignupServices
    {
        private readonly IMongoCollection<User> userCollectionName;
        private readonly IMapper _mapper;

        public SignupServices(ILearningprojectDatabaseSettings settings, IMongoClient mongoClient, IMapper mapper)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            userCollectionName = database.GetCollection<User>(settings.UsercollectionName);
            _mapper = mapper;
        }
        public async Task CreateAsync(User user)
        {
            await userCollectionName.InsertOneAsync(user);
        }

        public void Delete(string id)
        {
            userCollectionName.DeleteOneAsync(User => User.id == id);
        }

        public async Task<List<UserReadDto>> GetAsync()
        {
            var UserList =  await userCollectionName.Find(User=>true).ToListAsync();
            var UserListDto = _mapper.Map<List<UserReadDto>>(UserList);

            return UserListDto;
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

using EAD_WEB_API_Y4_S1.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace EAD_WEB_API_Y4_S1.Services
{
    public class UserService
    {
        private readonly IMongoCollection<Users> _UserCollection;

        public UserService(IOptions<UserStoreDatabaseSettings> userStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                userStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                userStoreDatabaseSettings.Value.DatabaseName);

            _UserCollection = mongoDatabase.GetCollection<Users>(
                userStoreDatabaseSettings.Value.UserCollectionName);
        }

        public async Task<List<Users>> GetAsync() =>
           await _UserCollection.Find(_ => true).ToListAsync();

        public async Task<Users?> GetAsync(string id) =>
            await _UserCollection.Find(x => x.UserId == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Users newUser) =>
            await _UserCollection.InsertOneAsync(newUser);

        public async Task UpdateAsync(string id, Users updatedUser) =>
            await _UserCollection.ReplaceOneAsync(x => x.UserId == id, updatedUser);

        public async Task RemoveAsync(string id) =>
            await _UserCollection.DeleteOneAsync(x => x.UserId == id);

    }
}

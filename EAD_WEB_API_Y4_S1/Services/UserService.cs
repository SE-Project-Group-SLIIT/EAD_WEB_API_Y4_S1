
////////////////////////////////////////////////////////////////////////////////////////////////////////
// FileName: UserService.cs
// FileType: C# Source file
// Author: Lalitha Maddumage
// Created On: 10/08/2023 1:56:39 AM
// Last Modified On: 10/13/2023 11:53:23 AM
// Copy Rights: N/A
// Description: Service class for user-related operations in the Web API
////////////////////////////////////////////////////////////////////////////////////////////////////////

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

        public async Task<Users?> GetByEmailAsync(string email) =>
        await _UserCollection.Find(x => x.Email == email).FirstOrDefaultAsync();

        public async Task<Users?> AuthenticateAsync(string email, string nic)
        {
            var user = await GetByEmailAsync(email);

            if (user != null && user.NIC == nic)
            {
                return user;
            }

            return null;
        }

    }
}

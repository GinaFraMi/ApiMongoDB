using ApiCRUDMongoDB.Infra;
using ApiCRUDMongoDB.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ApiCRUDMongoDB.Services;

public interface IUserService
{
    public Task<List<User>> GetAllUser();
    public Task<User?> GetUser(string id);
    public Task CreateUser(User user);
    public Task UpdateUser(string id, User user);
    public Task DeleteUser(string id);
}

public class UserService : IUserService
{
    private readonly IMongoCollection<User> _userCollection;

    public UserService(IOptions<ApiCRUDMongoBDDatabase> apiCRUDMongoBDDatabase)
    {
        var mongoClient = new MongoClient(apiCRUDMongoBDDatabase.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(apiCRUDMongoBDDatabase.Value.DatabaseName);
        _userCollection = mongoDatabase.GetCollection<User>(apiCRUDMongoBDDatabase.Value.UserCollectionName);

    }

    public async Task CreateUser(User user) => await _userCollection.InsertOneAsync(user);
    public async Task DeleteUser(string id) => await _userCollection.DeleteOneAsync(x => x.Id == id);
    public async Task<List<User>> GetAllUser() => await _userCollection.Find(_ => true).ToListAsync();
    public async Task<User?> GetUser(string id) => await _userCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
    public async Task UpdateUser(string id, User user) => await _userCollection.ReplaceOneAsync(x => x.Id == id, user);
}
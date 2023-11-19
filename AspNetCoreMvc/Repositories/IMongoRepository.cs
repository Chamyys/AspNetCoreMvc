using MongoDB.Bson;
using MongoDB.Driver;
using System.Net;
using SharpCompress.Common;
using AspNetCoreMvc.Models;

namespace Repository
{
    public interface IMongoRepository
    {
        public Task<string> Create(User user);
        public Task<bool> Delete(User user);
        public Task<User> Get(User user);
        public  Task<bool> IsLoginOccypided(User user);
        public Task<User> GetUserByLogin(Login user);
        public Task<List<UserMainInfo>> GetUserMainInfoList();
    }
}
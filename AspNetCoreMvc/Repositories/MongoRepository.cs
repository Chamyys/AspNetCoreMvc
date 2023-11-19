using AspNetCoreMvc.Models;
using MongoDB.Driver;
using SharpCompress.Common;
using System.Collections.Generic;

namespace Repository
{
    public class MongoRepository : IMongoRepository
    {

        private readonly IMongoCollection<User> users;

        public MongoRepository(IMongoClient client)
        {
            var database = client.GetDatabase("Mongo");
            var collection = database.GetCollection<User>("users");
            users = collection;
        }

        public async Task<string> Create(User user)
        {

            users.InsertOneAsync(user);
            return user.id;

        }

        public async Task<bool> Delete(User user)
        {
            try
            {
                var filter = Builders<User>.Filter.Eq(c => c.id, user.id);
                var result = users.DeleteOneAsync(filter);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<User> Get(User user)
        {

            var filter = Builders<User>.Filter.Eq(c => c.id, user.id);
            var curUser = users.Find(filter).FirstOrDefaultAsync();
            if (curUser.Result.id == null) curUser.Result.id = "Not Found";
            return curUser.Result;
        }
        public async Task<User> GetUserByLogin(Login user)
        {

            var filter = Builders<User>.Filter.Eq(c => c.login, user.login) & Builders<User>.Filter.Eq(c => c.password, user.password); ;
            var curUser = await users.Find(filter).FirstOrDefaultAsync();
            if (curUser == null)
            {
                User temp = new User();
                temp.id = "Not Found";
                return temp;
            }
            return curUser;
        }

        public async Task<List<UserMainInfo>> GetUserMainInfoList()
        {
            var mongoData = await users.Find(_ => true).ToListAsync();
            List<UserMainInfo> newlist = new List<UserMainInfo>();
            foreach (User user in mongoData)
            {
                var temp = new UserMainInfo();
                temp.id = user.id;
                temp.name = user.name;
                temp.surname = user.surname;
                temp.data = user.data;
                newlist.Add(temp);
            }
            return newlist;
        }
        public async Task<bool> IsLoginOccypided(User user)
        {

            var filter = Builders<User>.Filter.Eq(c => c.login, user.login);
            var curUser = await users.Find(filter).FirstOrDefaultAsync();
            if (curUser==null || curUser.login == null)
            {
                return false;
            }
            else
            {
                 return true;
            }
           
        }


    }
}
        
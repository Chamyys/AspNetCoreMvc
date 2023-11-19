using AspNetCoreMvc.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Repository;

namespace AspNetCoreMvc.Controllers;


public class MongoController : Controller
{
    private readonly IMongoRepository _mongoRepository;

    public MongoController(IMongoRepository mongoRepository)
    {
        _mongoRepository = mongoRepository;

    }

    public string Test()
    {
        User user = new User();
        user.id = "123";
        user.name = "ivas";
        user.surname = "kisasd";

        return _mongoRepository.Create(user).Result;
    }
    [HttpPost]
   
    public string Create([FromBody] User user)
    {
        return _mongoRepository.Create(user).Result;
    }
    [HttpPost]

    public bool IsLoginOccypided([FromBody] User user)
    {
        return _mongoRepository.IsLoginOccypided(user).Result;
    }
    public User Login([FromBody] Login user)
    {
        return _mongoRepository.GetUserByLogin(user).Result;
    }
    public List<UserMainInfo> getList()
    {
        return _mongoRepository.GetUserMainInfoList().Result;
    }

}

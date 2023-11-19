using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;
using AspNetCoreMvc.Models;
using System.Text.Json;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System;



namespace AspNetCoreMvc.Controllers;

public class HomeController : Controller
{
    // "/"
    // "/Home"
    // "/Home/Index"
    private readonly HttpClient _httpClient;

    public HomeController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    [HttpGet]
    public async Task<String> getMarsPhoto()
    {
        Random rnd = new Random();
        var sol = rnd.Next(1001, 1600);
        var apiUrl = $"https://api.nasa.gov/mars-photos/api/v1/rovers/curiosity/photos?sol={sol}&camera=fhaz&api_key=";
        var request = new HttpRequestMessage(HttpMethod.Get, apiUrl + "VlPsLUkC5OVesMngyOfiNYP2KpI0i3I71NX18yvO");
        var response = await _httpClient.SendAsync(request);
        var content = await response.Content.ReadAsStringAsync();
        // обработка данных, полученных из ответа
        NasaObject curData = new NasaObject();
        var a = JsonConvert.DeserializeObject<NasaObject>(content);
        return a.photos[0].img_src;
    }
    public IActionResult Index()
    {
       
        return View("Index");
    }

 
    public IActionResult Bio()
    {
        //return "Web Developer";
        return View();
    }
    public IActionResult Main()
    {
        //return "Web Developer";
        return View();
    }
    public IActionResult NewLive()
    {
        //return "Web Developer";
        return View();
    }
    public IActionResult Login()
    {
        //return "Web Developer";
        return View();
    }
    public IActionResult Register()
    {
        //return "Web Developer";
        return View();
    }
    public IActionResult Rovers()
    {
        //return "Web Developer";
        return View();
    }
}
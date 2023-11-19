using Microsoft.AspNetCore.Hosting;
using MongoDB.Bson;
using MongoDB.Driver;
using Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();

builder.WebHost.UseUrls("http://localhost:7001/");
builder.Services.AddTransient<IMongoRepository, MongoRepository>();
builder.Services.AddSingleton<IMongoClient>(sp => new MongoClient("mongodb://127.0.0.1:27017"));




builder.Services.AddControllersWithViews();


var app = builder.Build();





// Middlewares
app.UseHttpsRedirection();
app.UseStaticFiles();


app.MapDefaultControllerRoute();




app.Run();

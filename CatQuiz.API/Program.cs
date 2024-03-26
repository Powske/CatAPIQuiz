using CatQuiz.Logic;
using CatQuiz.Persistence.Persistence;
using CatQuiz.Persistence.ServiceConnector;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient("Cat", client =>
{
    //Setting the base address to the specified URL but forcing has breeds for the quiz to work
    client.BaseAddress = new Uri("https://api.thecatapi.com/v1/images/search?has_breeds=1");
    client.DefaultRequestHeaders.Add("x-api-key", "live_ud7ZI7SDrcAKb8eyLYFW2jQ3vdMe41uriL9vfh33M4PnAwTS9y0S5d8lVRihw0Tx");
});
builder.Services.AddHttpClient("Breed", client =>
{
    //Setting the base address to the specified URL but forcing has breeds for the quiz to work
    client.BaseAddress = new Uri("https://api.thecatapi.com/v1/breeds");
    client.DefaultRequestHeaders.Add("x-api-key", "live_ud7ZI7SDrcAKb8eyLYFW2jQ3vdMe41uriL9vfh33M4PnAwTS9y0S5d8lVRihw0Tx");
});
builder.Services.AddTransient<ILogic, Logic>();
builder.Services.AddTransient<ICatServiceConnector, CatServiceConnector>();
builder.Services.AddTransient<ICatQuizRepository, CatQuizRepository>();
builder.Services.AddDbContext<CatQuizContext>(x => x.UseSqlite(builder.Configuration.GetConnectionString("QuizDB")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
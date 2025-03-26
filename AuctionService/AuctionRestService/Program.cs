using AuctionData.DatabaseLayer;
using AuctionRestService.BusinesslogicLayer;
using AuctionService.BusinesslogicLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<IUserData, UserDataLogic>();
builder.Services.AddSingleton<IUserAccess, UserDatabaseAccess>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // You can pass options here if you want
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

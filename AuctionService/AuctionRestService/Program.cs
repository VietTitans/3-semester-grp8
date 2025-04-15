using AuctionData.DatabaseLayer;
using AuctionRestService.BusinesslogicLayer;
using AuctionService.BusinesslogicLayer;
using Microsoft.IdentityModel.Tokens;
using AuctionRestService.Security;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);



// Configure the JWT Authentication Service
builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = "JwtBearer";
    options.DefaultChallengeScheme = "JwtBearer";
})
           .AddJwtBearer("JwtBearer", jwtOptions => {
               jwtOptions.TokenValidationParameters = new TokenValidationParameters()
               {
                   // The SigningKey is defined in the TokensController class
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SecurityHelper(builder.Configuration).GetSecurityKey(),
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidIssuer = "https://localhost:7101",
                   ValidAudience = "https://localhost:7101",
                   ValidateLifetime = true
               };
           });

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton<IUserData, UserDataLogic>();
builder.Services.AddSingleton<IUserAccess, UserDatabaseAccess>();



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Auction API", Version = "v1" });

    // 🔐 Add JWT bearer security definition
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme.  
                        Enter 'Bearer' [space] and then your token in the text input below.  
                        Example: Bearer abcdef12345",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    // 🔐 Add security requirement to include the token in all endpoints
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});



var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // You can pass options here if you want
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

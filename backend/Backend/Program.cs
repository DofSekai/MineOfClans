using Backend.Business.Implementations;
using Backend.Business.Interfaces;
using Backend.Common;
using Backend.Database;
using Backend.Database.Implementations;
using Backend.Database.Interfaces;
using Business.Database.Implementations;
using Business.Database.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var rawConfig = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddEnvironmentVariables()
    .AddJsonFile("appsettings.json")
    .AddUserSecrets<Program>()
    .Build();

var appSettingsSection = rawConfig.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingsSection);

builder.Services.AddCors(options => {
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy => {
            policy.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader();
        });
});

builder.Services.AddHealthChecks().AddNpgSql(appSettingsSection["ConnectionString"]);

// Add services to the container.
builder.Services.AddTransient<DatabaseContext>();

// Services
builder.Services.AddTransient<IUsersService, UsersService>();
builder.Services.AddTransient<IVillagesService, VillagesService>();
builder.Services.AddTransient<ILevelMinesService, LevelMinesService>();

// Data
builder.Services.AddTransient<IUsersDataAccess, UsersDatabaseAccess>();
builder.Services.AddTransient<IVillagesDataAccess, VillagesDatabaseAccess>();
builder.Services.AddTransient<ILevelMinesDataAccess, LevelMinesDatabaseAccess>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope()) {
    var dbContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

    // Here is the migration executed
    dbContext.Database.Migrate();
}

app.Run();
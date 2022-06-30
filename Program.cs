using Learningproject.Helpers;
using Learningproject.Models;
using Learningproject.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<LearningprojectDatabaseSettings>(
    builder.Configuration.GetSection(nameof(LearningprojectDatabaseSettings)));

builder.Services.AddSingleton<ILearningprojectDatabaseSettings>(
    sp => sp.GetRequiredService<IOptions<LearningprojectDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
new MongoClient(builder.Configuration.GetValue<string>("LearningprojectDatabaseSettings:ConnectionString")));



builder.Services.AddScoped<ISignupServices, SignupServices>();
builder.Services.AddScoped<IUniqueEmailCheck, UniqueEmailCheck>();
builder.Services.AddScoped<IUniqueUserNameCheck, UniqueUserNameCheck>();
builder.Services.AddScoped<IPasswordValidation, PasswordValidation>();
builder.Services.AddScoped<IPasswordEncryption, PasswordEncryption>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// Registering auto mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

app.UseAuthorization();

app.MapControllers();

app.Run();

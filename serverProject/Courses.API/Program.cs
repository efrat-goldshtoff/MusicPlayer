using System.Text.Json.Serialization;
using Courses.Core;
using Courses.Core.Repositories;
using Courses.Core.Services;
using Courses.Data;
using Courses.Data.Repositories;
using Courses.Service;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IUserService, SongService>();
builder.Services.AddScoped<ISingerService, UserService>();
builder.Services.AddScoped<ISongtService, SingerService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<SongRepository, SongRepository>();
builder.Services.AddScoped<ISingerRepository, SingerRepository>();

builder.Services.AddDbContext<DataContext>();
//builder.Services.AddSingleton<DataContext>();


builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

//builder.Services.AddSingleton<Mapping>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

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

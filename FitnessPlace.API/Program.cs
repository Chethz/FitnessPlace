using System.Text.Json.Serialization;
using FitnessPlace.API.Middleware;
using FitnessPlace.Business.Mappings;
using FitnessPlace.Business.Services;
using FitnessPlace.Business.Services.IServices;
using FitnessPlace.DataAccess;
using FitnessPlace.DataAccess.Interfaces;
using FitnessPlace.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Database configuration
builder.Services.AddDbContext<FitnessPlaceDbContext>(
            options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection"),
                    x => x.MigrationsAssembly("FitnessPlace.DataAccess")));

//Add support to logging with SERILOG
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File("/Logs/log.txt", rollingInterval: RollingInterval.Day)
    .WriteTo.Seq("http://localhost:5341")
    .CreateLogger();

Log.Information("Applictaion Starting");

builder.Host.UseSerilog(Log.Logger);

//Adding automapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

//Middleware
builder.Services.AddTransient<ExceptionHandlingMiddleware>();

//Generic Repository
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

//Asset Mapping
builder.Services.AddScoped(typeof(IMemberService), typeof(MemberService));

//Fixing object cycle issue
builder.Services.AddControllers().AddJsonOptions(x =>
   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

//Disable Model State auto validation.
// builder.Services.Configure<Microsoft.AspNetCore.Mvc.ApiBehaviorOptions>(options =>
// {
//     options.SuppressModelStateInvalidFilter = true;
// });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();

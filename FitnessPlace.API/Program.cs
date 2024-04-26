using System.Text.Json.Serialization;
using FitnessPlace.Business.Mappings;
using FitnessPlace.Business.Services;
using FitnessPlace.DataAccess;
using FitnessPlace.DataAccess.Interfaces;
using FitnessPlace.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

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

builder.Services.AddAutoMapper(typeof(MappingProfile));

//Generic Repository
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

//Asset Mapping
builder.Services.AddScoped(typeof(MemberService), typeof(MemberService));

builder.Services.AddControllers().AddJsonOptions(x =>
   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

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

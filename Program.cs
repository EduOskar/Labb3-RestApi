using Microsoft.EntityFrameworkCore;
using Labb3_RestApi.Data;
using Labb3_RestApi.Repository;
using Labb3_RestApi.Repository.IRepository;
using Labb3_RestApi.Models;
using Labb3_RestApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IRepository<Person>, Repository<Person>>();
builder.Services.AddScoped<IRepository<Interest>, Repository<Interest>>();
builder.Services.AddScoped<IRepository<Links>, Repository<Links>>();

builder.Services.AddControllers();
//builder.Services.AddScoped<IRepository, Repository>();

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingConfig));
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

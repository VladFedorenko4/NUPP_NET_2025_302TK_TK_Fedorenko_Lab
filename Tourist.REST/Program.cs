using Microsoft.EntityFrameworkCore;
using Tourist.Infrastructure.Repository;
using Tourist.Infrastructure;
using Tourist.Common.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TouristContext>(options =>
    options.UseNpgsql("Host=localhost; Database=Tourist; Username=postgres; Password=3004"));

builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient(typeof(ICrudService<>), typeof(CrudService<>));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

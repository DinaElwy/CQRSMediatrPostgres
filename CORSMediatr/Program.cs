using CQRSMediatr.Behaviors;
using CQRSMediatr.DataStore;
using CQRSMediatr.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<EF_DataContext>(o=>o.UseNpgsql(builder.Configuration.GetConnectionString("Postgres_Db")));

// Add services to the container.
builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

builder.Services.AddControllers();

builder.Services.AddScoped<DbHelper>();
builder.Services.AddScoped<EF_DataContext>();

builder.Services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

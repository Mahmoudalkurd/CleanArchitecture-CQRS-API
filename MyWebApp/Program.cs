using MediatR;
using Microsoft.EntityFrameworkCore;
using MyApp1.Domain.Interfaces;
using MyApp1.Infrastructure.Data;
using MyApp1.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations; // For MigrationBuilder
using Npgsql.EntityFrameworkCore.PostgreSQL;    // For UseNpgsql()
using System;
using Serilog;

using System;
using MyApp1.Application.Commands;

var builder = WebApplication.CreateBuilder(args);
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

builder.Host.UseSerilog();

// Configuration & DB
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// MediatR (point to Application assembly)
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateStudentCommand).Assembly));

// DI: Generic repository for domain entities
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

// Controllers & Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
  var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
  db.Database.Migrate(); // auto-migrate on startup (helpful locally)
}

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

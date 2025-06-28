using Microsoft.EntityFrameworkCore;
using Shop.API.Extension;
using Shop.Auth.Extension;
using Shop.Data;
using System;

var builder = WebApplication.CreateBuilder(args);

var Configuration = builder.Configuration;

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
    x => x.MigrationsAssembly("Shop.Data")));

//Add JWT
builder.Services.AddJwtAuthentication(Configuration);

//Add DI
builder.Services.DIExtension();


builder.Services.AddAuthorization();

builder.Services.AddControllers();



builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

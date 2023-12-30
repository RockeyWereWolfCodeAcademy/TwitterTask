using Microsoft.EntityFrameworkCore;
using Twitter.DAL.Contexts;
using Twitter.Business;
using Twitter.Core.Entities;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TwitterContext>( options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("MSSql"))
).AddIdentity<AppUser, IdentityRole>( //options => 
   // options.
);
builder.Services.AddRepositories();
builder.Services.AddServices();
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

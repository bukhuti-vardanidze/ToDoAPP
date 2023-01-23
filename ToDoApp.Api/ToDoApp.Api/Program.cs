using Microsoft.EntityFrameworkCore;
using ToDoApp.Api.Auth;
using ToDoApp.Api.Db;
using ToDoApp.Api.Db.Entities;
using ToDoApp.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IAuthService, AuthService>();
AuthConfigurator.Configure(builder);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//
builder.Services.AddDbContextPool<AppDbContext>(c =>
    c.UseSqlServer(builder.Configuration["AppDbContextConnection"]));


builder.Services.AddTransient<ISendEmailRequestRepository, SendEmailRequestRepository>();


// =>
builder.Services.AddTransient<IToDoRequestRepository, ToDoRequestRepository>();

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

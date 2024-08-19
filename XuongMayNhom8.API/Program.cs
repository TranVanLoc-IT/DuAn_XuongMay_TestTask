using Microsoft.EntityFrameworkCore;
using XuongMayNhom8.Repositories.Models;
using XuongMayNhom8.Repositories.Repositories.UserRepository;
using XuongMayNhom8.Services.Services.UserService;
using XuongMayNhom8.Services.Services.OrderService;
using XuongMayNhom8.Repositories.Repositories.OrderRepository;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext and configure it with the connection string from appsettings.json
builder.Services.AddDbContext<XmbeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

//regis DI
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IOrderService, OrderService>();

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

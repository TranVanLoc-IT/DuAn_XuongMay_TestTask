using Microsoft.EntityFrameworkCore;
using XuongMayNhom8.Repositories.Implemenations;
using XuongMayNhom8.Repositories.Interfaces;
using XuongMayNhom8.Repositories.Models;
using XuongMayNhom8.Services.Implemetations;
using XuongMayNhom8.Services.Interfaces;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Add DbContext
builder.Services.AddDbContext<XmbeContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Add Repository and Service
builder.Services.AddScoped<IChuyenRepository, ChuyenRepository>();
builder.Services.AddScoped<IChuyenService, ChuyenService>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ITaskService, TaskService>();


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

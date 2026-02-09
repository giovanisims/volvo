using Microsoft.EntityFrameworkCore;
using AutoManage.Data;
using AutoManage.Services;
using AutoManage.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// ---- DATABASE
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString)); 
// ---- SWAGGER
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// ---- BUSINESS LOGIC
builder.Services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
builder.Services.AddScoped<IVehicleService, VehicleService>();
builder.Services.AddScoped<ISalespersonService, SalespersonService>();

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
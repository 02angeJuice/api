using Microsoft.EntityFrameworkCore;

using api.Data;
using api.Repository;
using api.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// -- Controller
builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// -- DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// -- Repository || Interfaces
builder.Services.AddScoped<IStockRepository, StockRepository>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



// -- Controller
app.UseHttpsRedirection();


app.MapControllers();


// app.UseStaticFiles(); // 🔴 here it is
// app.UseRouting(); // 🔴 here it is
// app.UseCors();

app.Run();


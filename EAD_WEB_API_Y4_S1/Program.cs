using EAD_WEB_API_Y4_S1.Models;
using EAD_WEB_API_Y4_S1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<TravelerStoreDatabaseSettings>(
    builder.Configuration.GetSection("StoreDatabase"));

builder.Services.Configure<TicketBookingsStoreDatabaseSettings>(
    builder.Configuration.GetSection("StoreDatabase"));

builder.Services.AddSingleton<TravelerService>();
builder.Services.AddSingleton<TicketBookingService>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

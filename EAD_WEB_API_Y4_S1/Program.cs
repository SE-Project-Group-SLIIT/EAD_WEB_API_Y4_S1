using EAD_WEB_API_Y4_S1.Models;
using EAD_WEB_API_Y4_S1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<TravelerStoreDatabaseSettings>(
    builder.Configuration.GetSection("StoreDatabase"));

builder.Services.Configure<TicketBookingsStoreDatabaseSettings>(
    builder.Configuration.GetSection("StoreDatabase"));

builder.Services.Configure<UserStoreDatabaseSettings>(
    builder.Configuration.GetSection("StoreDatabase"));

builder.Services.Configure<TrainsStoreDatabaseSettings>(
    builder.Configuration.GetSection("StoreDatabase"));

builder.Services.AddSingleton<TravelerService>();
builder.Services.AddSingleton<TicketBookingService>();
builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<TrainService>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder.WithOrigins("http://localhost:3000") // Replace with your client's origin
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();*/

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Add CORS middleware here
app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();


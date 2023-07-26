using Hotel_Booking_Backend.Models;
using Hotel_Booking_Backend.DAO;
using Hotel_Booking_Backend.Services;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json.Serialization;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// And ignore cycle refrenece
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});



//Add conection to the Azure SQL
//Make the realtion lazy loading
builder.Services.AddDbContext<HotelBookingContext>(options =>
                options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("AzureConnection")));

// Add DAO and Service layer
builder.Services.AddScoped<IHotelDAO, HotelDAO>();
builder.Services.AddScoped<IRoomDAO, RoomDAO>();
builder.Services.AddScoped<IBookingDAO, BookingDAO>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IHotelService, HotelService>();
builder.Services.AddScoped<IRoomService, RoomService>();


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


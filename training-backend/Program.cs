using Microsoft.EntityFrameworkCore;
using training_backend.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Entity Framework Core with SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure CORS
// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueApp",
        builder => builder
            .WithOrigins("http://10.10.100.232:8080", "http://localhost:5173", "https://localhost:5173") // Add your Vue.js app's origin
            .AllowAnyMethod() // Allow any HTTP method
            .AllowAnyHeader() // Allow any HTTP header
            .AllowCredentials()); // Allow credentials (cookies, authorization headers, etc.)
});


var app = builder.Build();

// Use CORS
app.UseCors("AllowVueApp");

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Enable Swagger in development mode
    app.UseSwaggerUI(); // Set up the Swagger UI
}

// Uncomment if both Vue and API are using HTTPS
// app.UseHttpsRedirection(); 

app.UseAuthorization(); // Enable authorization

// Map controller routes
app.MapControllers();

// Run the application
app.Run();

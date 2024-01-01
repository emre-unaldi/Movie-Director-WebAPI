using DataAccess;
using Business;
using Core.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Service DI
builder.Services.AddDataAccessServices(builder.Configuration);
builder.Services.AddBusinessServices();

builder.Services.AddMvc();

// Controllers
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Global Exception Handling
app.UseExceptionHandlingMiddleware();

app.MapControllers();

app.UseCors("AllowSpecificOrigin");

app.Run();

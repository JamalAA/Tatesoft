using Microsoft.EntityFrameworkCore;
using Tatesoft.WebAPI.Context;
using Tatesoft.WebAPI.Entities;
using Tatesoft.WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<TatesoftBackendDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("tatesoft"));
    options.EnableSensitiveDataLogging();
});

builder.Services.AddSingleton<LoggedInUser>();
builder.Services.AddScoped<OcrService>();
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<DtoServices>();

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

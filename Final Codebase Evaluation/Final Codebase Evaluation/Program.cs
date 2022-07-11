using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Final_Codebase_Evaluation.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Final_Codebase_EvaluationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Final_Codebase_EvaluationContext") ?? throw new InvalidOperationException("Connection string 'Final_Codebase_EvaluationContext' not found.")));

// Add services to the container.

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

app.UseAuthorization();

app.MapControllers();

app.UseCors(builder => builder
.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader());

app.Run();

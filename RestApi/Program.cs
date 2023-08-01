using Infrastructure;
using Core;

var builder = WebApplication.CreateBuilder(args);

//   from Infrastructure
builder.Services.RegisterDBConnectionString(builder.Configuration);
builder.Services.RegisterRepository();

//   from Core
builder.Services.RegisterServices();

builder.Services.AddControllers();
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

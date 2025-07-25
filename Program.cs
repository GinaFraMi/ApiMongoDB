using ApiCRUDMongoDB.Infra;
using ApiCRUDMongoDB.Middleware;
using ApiCRUDMongoDB.Services;
var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ApiCRUDMongoBDDatabase>(
    builder.Configuration.GetSection("ApiCRUDMongoBDDatabase")
);

builder.Services.AddSingleton<UserService>();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();


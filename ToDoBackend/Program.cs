using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using ToDoBackend.AppContext;
using ToDoBackend.AppServices;
using ToDoBackend.ConfigMapper;
using ToDoBackend.Repository;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

// //------USING DB CONECCTION SQL SERVER ---------
/*builder.Services.AddDbContext<EntityContext>(
    options => options.UseSqlServer(configuration.GetConnectionString("ToDo"), sqlServerOptionsAction: sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 15,
            maxRetryDelay: TimeSpan.FromSeconds(60),
            errorNumbersToAdd: null);
    })
);*/

// //-------- USING IN MEMORY DATABASE   -----------
builder.Services.AddDbContext<EntityContext>(
    options => options.UseInMemoryDatabase("ToDo")
);

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(MapperProfile));

// Services of system
builder.Services.AddTransient<ITodoAppService, TodoAppService>();

// Repositories
builder.Services.AddTransient<ToDoRepository>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//DOCUMENTATION API WITH SCALAR
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ADD CORS 
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins("http://localhost:3000", "http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //IF PREFER USE SWAGGER FOR DOCUMENTATION APIS OPEN BROWSER IN: https://localhost:7113/swagger/index.html
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
    //IF PREFER USE SCALAR FOR DOCUMENTATION APIS OPEN BROWSER IN: https://localhost:7113/scalar/v1
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options
        .WithTitle("SCALAR DOCUMENTATION API")
        .WithTheme(ScalarTheme.Mars)
        .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
    });
}

app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

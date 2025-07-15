using System.Text.Json.Serialization;
using Basboosify.API.Middlewares;
using Basboosify.Core;
using Basboosify.Core.Mappers;
using Basboosify.Infrastructure;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
//add infrastructure services
builder.Services.AddInfrastructure();
//add core services
builder.Services.AddCore();

//add controllers to service collection
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});


builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);

//fluent validation
builder.Services.AddFluentValidationAutoValidation();

//Add API explorer services
builder.Services.AddEndpointsApiExplorer();

//add swagger gen to create swagger
builder.Services.AddSwaggerGen();

//Add cors services
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});
    
//build the web app
var app = builder.Build();

app.UseExceptionHandlingMiddleware();

//routing
app.UseRouting();
//add endpoint that can serve swagger
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors();

//auth
app.UseAuthentication();
app.UseAuthorization();

//controller routes
app.MapControllers();

app.Run();

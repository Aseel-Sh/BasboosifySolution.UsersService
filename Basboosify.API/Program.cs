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

//build the web app
var app = builder.Build();

app.UseExceptionHandlingMiddleware();

//routing
app.UseRouting();

//auth
app.UseAuthentication();
app.UseAuthorization();

//controller routes
app.MapControllers();

app.Run();

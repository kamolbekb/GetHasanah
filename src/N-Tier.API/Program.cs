using System.Security.Claims;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using N_Tier.API;
using N_Tier.API.Filters;
using N_Tier.API.Middleware;
using N_Tier.Application;
using N_Tier.Application.Models.Validators;
using N_Tier.DataAccess;
using N_Tier.DataAccess.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(
    config => config.Filters.Add(typeof(ValidateModelAttribute))
);

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining(typeof(IValidationsMarker));

builder.Services.AddDbContext<DbContext>(options =>
    options.UseNpgsql("ConnectionString"));

builder.Services.AddSwagger();
builder.Services.AddSwaggerGen();

builder.Services.AddLogging();
   
builder.Services.AddDataAccess(builder.Configuration)
    .AddApplication(builder.Environment);

builder.Services.AddJwt(builder.Configuration);

builder.Services.AddEmailConfiguration(builder.Configuration);


var app = builder.Build();

using var scope = app.Services.CreateScope();

app.UseSwagger();
app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "N-Tier V1"); });

app.UseHttpsRedirection();

app.UseCors(corsPolicyBuilder =>
    corsPolicyBuilder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
);

app.UseRouting();

app.UseMiddleware<PerformanceMiddleware>();

app.UseMiddleware<TransactionMiddleware>();

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.MapControllers();

app.Run();

namespace N_Tier.API
{
    public partial class Program { }
}

using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Handlers.Extensions;
using TaskManager.DataAccess.Extensions;

const string databaseName = "taskmanager.db";

var builder = WebApplication.CreateBuilder(args);

InitServiceCollection(builder);
InitWebApplication(builder);

void InitServiceCollection(WebApplicationBuilder webApplicationBuilder)
{
    webApplicationBuilder.Services.AddHandlers();

    webApplicationBuilder.Services.AddDataAccess(x => x
        .UseSqlite($"Data Source={databaseName}")
        .UseLazyLoadingProxies());

    webApplicationBuilder.Services.AddControllers();

    webApplicationBuilder.Services.AddEndpointsApiExplorer();
    webApplicationBuilder.Services.AddSwaggerGen();
}

void InitWebApplication(WebApplicationBuilder webApplicationBuilder)
{
    var app = webApplicationBuilder.Build();

    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
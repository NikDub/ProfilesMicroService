using ProfilesMicroService.Api.Extensions;

namespace ProfilesMicroService.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.ConfigureJwtAuthentication(builder.Configuration);
        builder.Services.ConfigureDbConnection(builder.Configuration);
        builder.Services.ConfigureServices();
        builder.Services.ConfigureSwagger();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
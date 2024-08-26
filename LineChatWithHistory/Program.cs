using LineChatWithHistory.Configurations;

namespace LineChatWithHistory;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var configuration = builder.Configuration;

        // Add services to the container.
        builder.Services.AddAuthorization();
        builder.Services.AddControllers();
        builder.Services.AddLineMessagingApi(configuration);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}
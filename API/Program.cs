using API.Extensions;
using NLog;

var builder = WebApplication.CreateBuilder(args);

LogManager.Setup(options => options.LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/Nlog.config")));

builder.Services.ConfigureCors();

builder.Services.ConfigureLoggerService();

builder.Services.AddControllers();

var app = builder.Build();

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

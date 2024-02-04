
using dinnerLight.Application;
using dinnerLight.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
// basically service injection
    builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

    builder.Services.AddControllers();
}


var app = builder.Build();
//https request configuration
{
app.UseHttpsRedirection();
app.MapControllers();
Console.WriteLine("starting the server at {localhost:5251}");
app.Run();
}





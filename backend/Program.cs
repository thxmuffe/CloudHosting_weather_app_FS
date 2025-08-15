var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!"); // Using "anonomous functions"
app.MapGet("hellous/", HelloMehthod);

app.Run();

string HelloMehthod()
{
    // Soon we add code, which reads the message from a file...
    var message = "Moicca";
    return message + "!";
}

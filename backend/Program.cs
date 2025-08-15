var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!"); // Using "anonomous functions"
app.MapGet("hellous/", HelloMehthod);

app.Run();

string HelloMehthod()
{
    var message = File.ReadAllText("hello.txt");
    return "Read from FILE:\n\n" + message;
}

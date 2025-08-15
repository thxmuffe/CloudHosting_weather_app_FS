var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello NET24S!"); // Using "anonomous functions"
app.MapGet("hellous/", GetHello);

app.Run();

string GetHello()
{
    var helloFolder = new DirectoryInfo(Directory.GetCurrentDirectory());
    var helloPath = Path.Combine(helloFolder.FullName, "hello.txt");

    // print to console absolute path (Fullname)
    Console.WriteLine($"Reading hello from: {helloPath}");

    var message = File.ReadAllText(helloPath);
    return "Read from FILE:\n\n" + message;
}


// Deploy with:
// az webapp up --name my-super-best-net24s-chapp -g test1 --location westeurope --sku B1 --os-type linux


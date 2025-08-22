// 1)
var builder = WebApplication.CreateBuilder(args);

// 2)
// we may need to configuire builder before building (as an example, add controllers etc.)

// 3)
var app = builder.Build();

// 4)
// MAP.     ENDPOINT <-> metodi()
app.MapGet("hellous/", GetHello);
app.MapGet("/", () => "Hello NET24S!"); // Using "anonomous functions"

// 5).   after run.... program will stop here to wait for GET/POPST/UPDATE calls..
app.Run();
// -------------------------------------------------------------

Console.WriteLine("This should never happen... (is impossible, should be at least)");
// we will never get here...

// What about these??
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


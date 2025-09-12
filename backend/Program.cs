// Print to console information about program paths when program stars
// Later we can also send this information to logger (application insights / NLogger, SeriLog etc.)
Console.WriteLine(@$"Current Directory:
     {Directory.GetCurrentDirectory()}");

Console.WriteLine(@$"Executing Assembly: 
    {Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)}");


            


// 1)
var builder = WebApplication.CreateBuilder(args);

// 2)
// we may need to configuire builder before building (as an example, add controllers etc.)

// 3)
var app = builder.Build();

// 4)
// MAP.     ENDPOINT <-> metodi()
app.MapGet("hellous/", GetHello);
app.MapGet("/", () => "Hello NET24S Ryhmä (pieni muutos 12.9.2025)!"); // Using "anonomous functions"

// 5).   after run.... program will stop here to wait for GET/POPST/UPDATE calls..
app.Run();
// -------------------------------------------------------------

Console.WriteLine("This should never happen... (is impossible, should be at least)");
// we will never get here...

// What about these??
string GetHello()
{
    // 1) Determine hello.txt full file path (look in the same folder as program files are)
    //    Using Path.Combine allows use to not worry about the
    //    Operating system separator (is it /, \\, or what.??)
    var helloFolder = new DirectoryInfo(
        Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
    );
    var helloPath = Path.Combine(helloFolder.FullName, "hello.txt");

    // 2) Check that file exists, otherwise it may result into HTTP ERROR CODE 500
    if (!File.Exists(helloPath)) {
        return
@$"Sorry, can't return hello from file. File '{helloPath}' not found.
Please Contact your IT support";
    }
    
    // 3) file was found OK, print debug info to console absolute path (Fullname)
    Console.WriteLine($"FILE FOUND! Yippee! Reading hello from: {helloPath}");

    // 4) Read the actual content of the file and return his to the HTTP GET HANDLER
    var message = File.ReadAllText(helloPath);
    return "Read from FILE:\n\n" + message;
}




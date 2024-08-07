// See https://aka.ms/new-console-template for more information
Console.WriteLine("Java Version Selector Prototype");

string fileName = AppDomain.CurrentDomain.BaseDirectory + "\\jre.json";
if (!File.Exists(fileName))
{
    File.WriteAllText(fileName, "{}");
}


Dictionary<string, string> javaVersionPaths = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText(fileName));

//File.WriteAllText(fileName, System.Text.Json.JsonSerializer.Serialize(javaVersionPaths));

if (args.Length > 0)
{
    string key = javaVersionPaths.Keys.First();
    Console.Write("> ");
    string input = Console.ReadLine() ?? key;
    if (javaVersionPaths.ContainsKey(input))
    {
        key = input;
    }
    string jarPath = args[0];
    string command = $"\"{javaVersionPaths[key]}\" -jar \"{jarPath}\"";
    Console.WriteLine($"Launching {jarPath} with {key}");
    System.Diagnostics.Process.Start(command); 
}

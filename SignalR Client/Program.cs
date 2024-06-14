using Microsoft.AspNetCore.SignalR.Client;

Console.Write("IP -> ");
string? ip = Console.ReadLine();

Console.Write("Port -> ");
string? port = Console.ReadLine();

if (string.IsNullOrEmpty(ip) || string.IsNullOrEmpty(port))
{
    Console.WriteLine("Please provide a valid IP and port");
    Console.ReadKey();

    Environment.Exit(-1);
}

try
{
    HubConnection hubConnection = new HubConnectionBuilder().WithUrl($"http://{ip}:{port}/chat").Build();
    await hubConnection.StartAsync();

    hubConnection.On<string>("ReceiveMessage", (message) =>
    {
        Console.WriteLine(message);
    });

    hubConnection.On<string>("Kick", (reason) =>
    {
        Console.WriteLine(reason);
        Console.ReadKey();

        Environment.Exit(0);
    });

    while (true)
    {
        await Task.Delay(100);
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
    Console.ReadKey();

    Environment.Exit(-1);
}
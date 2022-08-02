using Microsoft.AspNetCore.SignalR.Client;

public class Program
{
    private static void Main(string[] args)
    {
        HubConnection connection;

        const string url = "https://localhost:7035/chat";

        connection = new HubConnectionBuilder()
            .WithUrl(url)
            .Build();

        connection.StartAsync().Wait();
        System.Console.WriteLine("Digite o seu nome: ");
        string name = Console.ReadLine();
        System.Console.WriteLine("Digite a mensagem: ");
        string msg = Console.ReadLine();
        connection.InvokeCoreAsync("SendMessage", args: new[] { name, msg });
        connection.On("ReceiveMessage", (string username, string message) =>
        {
            Console.WriteLine(username + ':' + message);
        });

        Console.ReadKey();
    }
}
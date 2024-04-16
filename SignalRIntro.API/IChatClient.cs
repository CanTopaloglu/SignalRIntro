namespace SignalRIntro.API;

public interface IChatClient
{
    Task ReceiveMessage(string message);
}

using Microsoft.AspNetCore.SignalR;
using SignalRIntro.API;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("broadcast", async (string message,IHubContext<ChatHub, IChatClient> context) =>
{
    await context.Clients.All.ReceiveMessage(message);

    return Results.NoContent();
});
app.UseHttpsRedirection();

app.MapHub<ChatHub>("chat-hub");

app.UseAuthorization();

app.MapControllers();

app.Run();

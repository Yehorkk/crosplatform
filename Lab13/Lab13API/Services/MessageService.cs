using App.Models;

namespace App.Services;

public class MessageService : IMessageService
{
    public Message GetProtectedMessage()
    {
        return new Message { text = "This is a protected message." };
    }

    public Message GetPublicMessage()
    {
        return new Message { text = "This is a public message." };
    }
}

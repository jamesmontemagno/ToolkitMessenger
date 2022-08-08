
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MauiApp2.Messages;

public class DeleteItemMessage : ValueChangedMessage<string>
{
    public DeleteItemMessage(string value) : base(value)
    {
    }
}

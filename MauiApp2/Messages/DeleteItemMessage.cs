
using CommunityToolkit.Mvvm.Messaging.Messages;
using MauiApp2.ViewModel;
using MediatR;

namespace MauiApp2.Messages;

public class DeleteItemMessage : ValueChangedMessage<string>
{
    public DeleteItemMessage(string value) : base(value)
    {
    }
}

public class DeleteNotification : INotification
{
    public string Value { get; set; }
}

public class DeleteNotificationHandler : INotificationHandler<DeleteNotification>
{
    MainViewModel viewModel;
    public DeleteNotificationHandler(MainViewModel viewModel)
    {
        this.viewModel = viewModel;
    }

    public Task Handle(DeleteNotification notification, CancellationToken cancellationToken)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            viewModel.DeleteCommand.Execute(notification.Value);
        });

        return Task.CompletedTask;
    }
}

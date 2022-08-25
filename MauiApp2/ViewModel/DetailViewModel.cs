using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MauiApp2.Messages;
using MediatR;

namespace MauiApp2.ViewModel;

[QueryProperty("Text", "Text")]
public partial class DetailViewModel : ObservableObject
{
    IMediator mediator;
    public DetailViewModel(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [ObservableProperty]
    string text;

    [RelayCommand]
    async Task GoBack()
    {
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    async Task Delete()
    {
        await mediator.Publish(new DeleteNotification
        {
            Value = Text
        });
        //WeakReferenceMessenger.Default.Send(new DeleteItemMessage(Text));
        await GoBack();
    }

    [RelayCommand]
    async Task GetCount()
    {
        var count = await mediator.Send(new GetCountRequest());
        await Shell.Current.DisplayAlert("Count", $"{count}", "OK");
    }
}

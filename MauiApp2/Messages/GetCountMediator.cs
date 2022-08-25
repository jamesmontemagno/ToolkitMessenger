using MauiApp2.ViewModel;
using MediatR;

namespace MauiApp2.Messages;

public class GetCountRequest : IRequest<int>
{
    public bool TacoStuffOnly {get;set;}
}

public class GetCountHandler : IRequestHandler<GetCountRequest, int>
{
    MainViewModel viewModel;
    public GetCountHandler(MainViewModel viewModel)
    {
        this.viewModel = viewModel;
    }

    public Task<int> Handle(GetCountRequest request, CancellationToken cancellationToken)
    {
        return Task.FromResult(viewModel.Items.Count);
    }
}

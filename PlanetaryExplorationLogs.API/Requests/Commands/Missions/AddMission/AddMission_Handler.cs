// The handler class is responsible for executing the query
public class AddMission_Handler : HandlerBase<returntype>
{
    private readonly int _someInputParameter;

    public AddMission_Handler(PlanetExplorationDbContext context, int someInputParameter)
        : base(context)
    {
        _someInputParameter = someInputParameter;
    }

    public override async Task<RequestResult<returntype>> HandleAsync()
    {
        await Task.CompletedTask;

        var mathematical = _someInputParameter * _someInputParameter;

        var result = new RequestResult<returntype>
        {
            Data = mathematical
        };

        return result;
    }
}
// The handler class is responsible for executing the query
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

public class AddMission_Handler : HandlerBase<int>
{
    private readonly int _someInputParameter;

    public AddMission_Handler(PlanetExplorationDbContext context, int someInputParameter)
        : base(context)
    {
        _someInputParameter = someInputParameter;
    }

    public override async Task<RequestResult<int>> HandleAsync()
    {
        await Task.CompletedTask;


        var result = new RequestResult<int>
        {
            Data = 5
        };

        return result;
    }
}
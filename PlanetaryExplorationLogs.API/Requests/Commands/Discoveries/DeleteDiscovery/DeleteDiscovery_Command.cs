using PlanetaryExplorationLogs.API.Data.Context;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Discoveries.DeleteDiscovery;

public class DeleteDiscovery_Command : RequestBase<int>
{
    private readonly int _discoveryId;

    public DeleteDiscovery_Command(PlanetExplorationDbContext context, int discoveryId)
        : base(context)
    {
        _discoveryId = discoveryId;
    }

    // The validator is optional and can be removed if not needed
    public override IValidator Validator =>
        new DeleteDiscovery_Validator(DbContext, _discoveryId);

    // The handler is mandatory to have for every command
    public override IHandler<int> Handler =>
        new DeleteDiscovery_Handler(DbContext, _discoveryId);
}


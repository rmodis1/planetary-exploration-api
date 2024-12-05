using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Discoveries.UpdateDiscovery;
public class UpdateDiscovery_Command : RequestBase<int>
{
    private readonly DiscoveryFormDto _discovery;

    public UpdateDiscovery_Command(PlanetExplorationDbContext context, DiscoveryFormDto discovery)
        : base(context)
    {
        _discovery = discovery;
    }

    // The authorizer, validator, and handler run in that order. If any fail, the query will not be executed.

    // The validator is optional and can be removed if not needed
    public override IValidator Validator =>
        new UpdateDiscovery_Validator(DbContext, _discovery);

    // The handler is mandatory to have for every command
    public override IHandler<int> Handler =>
        new UpdateDiscovery_Handler(DbContext, _discovery);
}
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Discoveries.GetDiscovery;
public class GetDiscovery_Query : RequestBase<DiscoveryFormDto>
{
    private readonly int _discoveryId;

    public GetDiscovery_Query(PlanetExplorationDbContext context, int discoveryId)
        : base(context)
    {
        _discoveryId = discoveryId;
    }

    // The validator is optional and can be removed if not needed
    public override IValidator Validator => new GetDiscovery_Validator(DbContext, _discoveryId);

    // The handler is mandatory to have for every query
    public override IHandler<DiscoveryFormDto> Handler => new GetDiscovery_Handler(DbContext, _discoveryId);
}


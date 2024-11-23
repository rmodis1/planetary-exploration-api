//// Paste these using statements at the top of the file and uncomment them
//using Microsoft.EntityFrameworkCore;
//using PlanetaryExplorationLogs.API.Utility.Patterns;
//using System.Net;
//using PlanetaryExplorationLogs.API.Data.Context;
//using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

public class GetDiscovery_Query : RequestBase<DiscoveryFormDto>
{
    private readonly int _id;

    public GetDiscovery_Query(PlanetExplorationDbContext context, int id)
        : base(context)
    {
        _id = id;
    }

    // The validator is optional and can be removed if not needed
    public override IValidator Validator => new GetDiscovery_Validator(DbContext, _id);

    // The handler is mandatory to have for every query
    public override IHandler<DiscoveryFormDto> Handler => new GetDiscovery_Handler(DbContext, _id);
}


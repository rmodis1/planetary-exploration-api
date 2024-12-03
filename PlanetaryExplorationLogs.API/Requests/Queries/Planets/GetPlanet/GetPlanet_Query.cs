// Paste these using statements at the top of the file and uncomment them
using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using System.Net;
using PlanetaryExplorationLogs.API.Data.Context;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;
using PlanetaryExplorationLogs.API.Data.Models;

public class GetPlanet_Query : RequestBase<Planet>
{
    private readonly int _planetId;

    public GetPlanet_Query(PlanetExplorationDbContext context, int planetId)
        : base(context)
    {
        _planetId = planetId;
    }

    // The validator is optional and can be removed if not needed
    public override IValidator Validator => new GetPlanet_Validator(DbContext, _planetId);

    // The handler is mandatory to have for every query
    public override IHandler<Planet> Handler => new GetPlanet_Handler(DbContext, _planetId);
}
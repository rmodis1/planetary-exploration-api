// The handler class is responsible for executing the query
using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

public class GetPlanet_Handler : HandlerBase<Planet>
{
    private readonly int _planetId;

    public GetPlanet_Handler(PlanetExplorationDbContext context, int planetId)
        : base(context)
    {
        _planetId = planetId;
    }

    public override async Task<RequestResult<Planet>> HandleAsync()
    {
        var somePlanet = await DbContext.Planets.FirstOrDefaultAsync(u => u.Id == _planetId);

        // Return the data
        var result = new RequestResult<Planet> { Data = somePlanet };

        return result;
    }
}
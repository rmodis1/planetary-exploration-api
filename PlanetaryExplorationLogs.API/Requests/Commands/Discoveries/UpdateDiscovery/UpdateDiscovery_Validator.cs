using System.Net;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Discoveries.UpdateDiscovery;

public class UpdateDiscovery_Validator : ValidatorBase
{
    private readonly DiscoveryFormDto _discovery;

    public UpdateDiscovery_Validator(PlanetExplorationDbContext context, DiscoveryFormDto discovery)
        : base(context)
    {
        _discovery = discovery;
    }

    public override async Task<RequestResult> ValidateAsync()
    {
        await Task.CompletedTask;

        if (!DbContext.Discoveries.Any(p => p.Id == _discovery.Id))
        {
            return await InvalidResultAsync(
                HttpStatusCode.BadRequest,
                "No discovery exists with the given ID.");
        }

        if(string.IsNullOrEmpty(_discovery.Name.Trim()))
        {
            return await InvalidResultAsync(
                HttpStatusCode.BadRequest,
                "The discovery must have a name.");
        }   

        if (_discovery.MissionId == 0 || !DbContext.Missions.Any(m => m.Id == _discovery.MissionId))
        {
            return await InvalidResultAsync(
                HttpStatusCode.BadRequest,
                "You must provide a valid mission id.");
        }

        if (_discovery.DiscoveryTypeId == 0 || !DbContext.DiscoveryTypes.Any(dt => dt.Id == _discovery.DiscoveryTypeId))
        {
            return await InvalidResultAsync(
                HttpStatusCode.BadRequest,
                "You must provide a valid discovery type id.");
        }

        return await ValidResultAsync();
    }
}
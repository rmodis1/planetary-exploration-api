using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using System.Net;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Missions.CreateDiscoveryForMission;

public class AddDiscoveryForMission_Validator : ValidatorBase
{
    private readonly DiscoveryFormDto _discovery;

    public AddDiscoveryForMission_Validator(PlanetExplorationDbContext context, DiscoveryFormDto discovery)
        : base(context)
    {
        _discovery = discovery;
    }

    public override async Task<RequestResult> ValidateAsync()
    {
        await Task.CompletedTask;

        if (_discovery == null)
        {
            return await InvalidResultAsync(
                HttpStatusCode.BadRequest,
                "You must provide some discovery to add.");
        }

        if (_discovery.MissionId <= 0)
        {
            return await InvalidResultAsync(
                HttpStatusCode.BadRequest,
                "Please supply a valid mission id.");
        }

        if (string.IsNullOrWhiteSpace(_discovery.Name))
        {
            return await InvalidResultAsync(
                HttpStatusCode.BadRequest,
                "Discovery name cannot be empty.");
        }

        if (_discovery.DiscoveryTypeId <= 0)
        {
            return await InvalidResultAsync(
                HttpStatusCode.BadRequest,
                "The given discovery type is not valid. Please provide a valid discovery type.");
        }

        return await ValidResultAsync();
    }
}
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using System.Net;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

// The validator class is responsible for validating things before the query is executed
public class AddDiscoveryForMission_Validator : ValidatorBase
{
    private readonly DiscoveryFormDto _discovery;
    private readonly int _missionId;

    public AddDiscoveryForMission_Validator(PlanetExplorationDbContext context, int missionId, DiscoveryFormDto discovery)
        : base(context)
    {
        _missionId = missionId;
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

        if (_missionId <= 0)
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
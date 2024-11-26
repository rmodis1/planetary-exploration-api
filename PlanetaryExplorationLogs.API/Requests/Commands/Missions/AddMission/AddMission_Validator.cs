
// The validator class is responsible for validating things before the query is executed
using System.Net;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Missions.AddMission;

public class AddMission_Validator : ValidatorBase
{
    private readonly MissionFormDto _mission;

    public AddMission_Validator(PlanetExplorationDbContext context, MissionFormDto mission)
        : base(context)
    {
        _mission = mission;
    }

    public override async Task<RequestResult> ValidateAsync()
    {
        await Task.CompletedTask;

        if (string.IsNullOrEmpty(_mission.Name.Trim()))
        {
            return await InvalidResultAsync(
                HttpStatusCode.BadRequest,
                "The mission must have a name.");
        }

        if (_mission.Date == DateTime.MinValue)
        {
            return await InvalidResultAsync(
                HttpStatusCode.BadRequest,
                "The mission must have a date.");
        }

        if (_mission.PlanetId == 0 || !DbContext.Planets.Any(p => p.Id == _mission.PlanetId))
        {
            return await InvalidResultAsync(
                HttpStatusCode.BadRequest,
                "You must provide a valid planet id.");
        }

        return await ValidResultAsync();
    }
}
using System.Net;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Missions.UpdateMission;

public class UpdateMission_Validator : ValidatorBase
{
    private readonly MissionDto _mission;

    public UpdateMission_Validator(PlanetExplorationDbContext context, MissionDto mission)
        : base(context)
    {
        _mission = mission;
    }

    public override async Task<RequestResult> ValidateAsync()
    {
        await Task.CompletedTask;

        if (!DbContext.Missions.Any(p => p.Id == _mission.Id))
        {
            return await InvalidResultAsync(
                HttpStatusCode.BadRequest,
                "No mission exists with the given ID.");
        }

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

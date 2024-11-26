using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using SQLitePCL;
using System.Net;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;


namespace PlanetaryExplorationLogs.API.Requests.Commands.Missions.DeleteMission;

// The validator class is responsible for validating things before the query is executed
public class DeleteMission_Validator : ValidatorBase
{
    private readonly int _missionId;

    public DeleteMission_Validator(PlanetExplorationDbContext context, int missionId)
        : base(context)
    {
        _missionId = missionId;
    }

    public override async Task<RequestResult> ValidateAsync()
    {
        await Task.CompletedTask;

        if (!await DbContext.Missions.AnyAsync(m => m.Id == _missionId))
        {
            return await InvalidResultAsync(
                HttpStatusCode.BadRequest,
                "No mission exists with the given ID.");
        }

        return await ValidResultAsync();
    }
}
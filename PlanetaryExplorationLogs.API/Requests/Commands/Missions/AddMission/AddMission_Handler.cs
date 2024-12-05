using System.Net;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Missions.AddMission;

public class AddMission_Handler : HandlerBase<int>
{
    private readonly MissionFormDto _mission;

    public AddMission_Handler(PlanetExplorationDbContext context, MissionFormDto mission)
        : base(context)
    {
        _mission = mission;
    }

    public override async Task<RequestResult<int>> HandleAsync()
    {
        var newMission = new Mission
        {
            Name = _mission.Name,
            Description = _mission.Description,
            Date = _mission.Date,
            PlanetId = _mission.PlanetId
        };

        await DbContext.Missions.AddAsync(newMission);
        await DbContext.SaveChangesAsync();

        var result = new RequestResult<int>
        {
            Data = newMission.Id,
            StatusCode = HttpStatusCode.Created
        };

        return result;
    }
}
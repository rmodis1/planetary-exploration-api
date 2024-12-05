using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Missions.GetMission;
public class GetMission_Handler : HandlerBase<Mission>
{
    private readonly int _missionId;

    public GetMission_Handler(PlanetExplorationDbContext context, int missionId)
        : base(context)
    {
        _missionId = missionId;
    }

    public override async Task<RequestResult<Mission>> HandleAsync()
    {
        var mission = await DbContext.Missions
            .Where(u => u.Id == _missionId)
            .Select(u => new Mission
            {
                Id = u.Id,
                Name = u.Name,
                Description = u.Description,
                Date = u.Date,
                PlanetId = u.PlanetId,
            })
            .FirstOrDefaultAsync();

        // Return the data
        var result = new RequestResult<Mission> { Data = mission };

        return result;
    }
}
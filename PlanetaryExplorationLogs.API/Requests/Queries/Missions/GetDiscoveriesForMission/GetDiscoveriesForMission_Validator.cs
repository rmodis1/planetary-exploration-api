using PlanetaryExplorationLogs.API.Utility.Patterns;
using System.Net;
using PlanetaryExplorationLogs.API.Data.Context;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Missions.GetDiscoveriesForMission;

public class GetDiscoveriesForMission_Validator : ValidatorBase
{
    private readonly int _missionId;

    public GetDiscoveriesForMission_Validator(PlanetExplorationDbContext context, int missionId)
        : base(context)
    {
        _missionId = missionId;
    }

    public override async Task<RequestResult> ValidateAsync()
    {
        if (!DbContext.Discoveries.Any(d => d.MissionId == _missionId))
        {
            return await InvalidResultAsync(
                HttpStatusCode.NotFound,
                "No discoveries can be found linked to that mission.");
        }

        // You can also check things in the database, if needed, such as checking if a record exists
        return await ValidResultAsync();
    }
}
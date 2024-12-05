using System.Net;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Missions.GetMission;

public class GetMission_Validator : ValidatorBase
{
    private readonly int _missionId;

    public GetMission_Validator(PlanetExplorationDbContext context, int missionId)
        : base(context)
    {
        _missionId = missionId;
    }

    public override async Task<RequestResult> ValidateAsync()
    {

        if (_missionId < 1)
        {
            return await InvalidResultAsync(
                HttpStatusCode.BadRequest,
                "You must provide a valid mission id.");
        }

        if (!DbContext.Missions.Any(m => m.Id == _missionId))
        {
            return await InvalidResultAsync(
                HttpStatusCode.NotFound,
                $"The mission with the ID {_missionId} does not exist in the database.");
        }

        // You can also check things in the database, if needed, such as checking if a record exists
        return await ValidResultAsync();
    }
}
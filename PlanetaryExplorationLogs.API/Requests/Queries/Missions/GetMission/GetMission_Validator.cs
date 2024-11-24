
// The validator class is responsible for validating things before the query is executed
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
        // Obviously, this is dummy validation logic. Replace it with your own.
        await Task.CompletedTask;
        if (string.IsNullOrEmpty(_missionId))
        {
            return await InvalidResultAsync(
                HttpStatusCode.BadRequest,
                "Need to have a value for the filter, apparently.");
        }

        // You can also check things in the database, if needed, such as checking if a record exists
        return await ValidResultAsync();
    }
}
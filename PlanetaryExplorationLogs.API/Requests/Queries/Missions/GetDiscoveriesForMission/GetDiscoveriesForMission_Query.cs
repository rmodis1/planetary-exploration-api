using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using System.Net;
using PlanetaryExplorationLogs.API.Data.Context;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;
using PlanetaryExplorationLogs.API.Data.Models;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Missions.GetDiscoveriesForMission;

public class GetDiscoveriesForMission_Query : RequestBase<List<Discovery>>
{
    private readonly int _missionId;

    public GetDiscoveriesForMission_Query(PlanetExplorationDbContext context, int missionId)
        : base(context)
    {
        _missionId = missionId;
    }

    // The authorizer, validator, and handler run in that order. If any fail, the query will not be executed.

    // The validator is optional and can be removed if not needed
    public override IValidator Validator => new GetDiscoveriesForMission_Validator(DbContext, _missionId);

    // The handler is mandatory to have for every query
    public override IHandler<List<Discovery>> Handler => new GetDiscoveriesForMission_Handler(DbContext, _missionId);
}
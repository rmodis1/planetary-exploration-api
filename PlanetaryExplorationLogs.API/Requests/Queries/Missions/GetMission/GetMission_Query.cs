//// Paste these using statements at the top of the file and uncomment them
//using Microsoft.EntityFrameworkCore;
//using PlanetaryExplorationLogs.API.Utility.Patterns;
//using System.Net;
//using PlanetaryExplorationLogs.API.Data.Context;
//using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using PlanetaryExplorationLogs.API.Data.Models;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Missions.GetMission;
public class GetMission_Query : RequestBase<Mission>
{
    private readonly int _missionId;

    public GetMission_Query(PlanetExplorationDbContext context, int missionId)
        : base(context)
    {
        _missionId = missionId;
    }

    // The validator is optional and can be removed if not needed
    public override IValidator Validator => new GetMission_Validator(DbContext, _missionId);

    // The handler is mandatory to have for every query
    public override IHandler<Mission> Handler => new GetMission_Handler(DbContext, _missionId);
}
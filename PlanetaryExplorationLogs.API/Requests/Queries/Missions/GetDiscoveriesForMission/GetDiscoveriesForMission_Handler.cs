using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using System.Net;
using PlanetaryExplorationLogs.API.Data.Context;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;
using PlanetaryExplorationLogs.API.Data.Models;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Missions.GetDiscoveriesForMission;


// The handler class is responsible for executing the query
public class GetDiscoveriesForMission_Handler : HandlerBase<List<Discovery>>
{
    private readonly int _missionId;

    public GetDiscoveriesForMission_Handler(PlanetExplorationDbContext context, int missionId)
        : base(context)
    {
        _missionId = missionId;
    }

    public override async Task<RequestResult<List<Discovery>>> HandleAsync()
    {
        var discoveries = await DbContext.Discoveries
            .OrderBy(d => d.Name)
            .Where(d => d.MissionId == _missionId)
            .GroupBy(d => d.DiscoveryTypeId)
            .ToListAsync();

        // Return the data
        var result = new RequestResult<List<Discovery>> { Data = discoveries.SelectMany(d => d).ToList() };

        return result;
    }
}
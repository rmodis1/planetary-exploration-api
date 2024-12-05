using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Discoveries.GetDiscovery;
public class GetDiscovery_Handler : HandlerBase<DiscoveryFormDto>
{
    private readonly int _discoveryId;

    public GetDiscovery_Handler(PlanetExplorationDbContext context, int discoveryId)
        : base(context)
    {
        _discoveryId = discoveryId;
    }

    public override async Task<RequestResult<DiscoveryFormDto>> HandleAsync()
    {
        var discovery = await DbContext.Discoveries
            .Where(u => u.Id == _discoveryId)
            .Select(u => new DiscoveryFormDto
            {
                Name = u.Name,
                Description = u.Description,
                MissionId = u.MissionId,
                Location = u.Location,
                DiscoveryTypeId = u.DiscoveryTypeId
            })
            .FirstAsync();

        // Return the data
        var result = new RequestResult<DiscoveryFormDto> { Data = discovery };

        return result;
    }
}
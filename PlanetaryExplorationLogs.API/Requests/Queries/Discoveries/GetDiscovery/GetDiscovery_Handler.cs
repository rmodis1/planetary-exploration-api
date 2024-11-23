// The handler class is responsible for executing the query
using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

public class GetDiscovery_Handler : HandlerBase<DiscoveryFormDto>
{
    private readonly int _id;

    public GetDiscovery_Handler(PlanetExplorationDbContext context, int id)
        : base(context)
    {
        _id = id;
    }

    public override async Task<RequestResult<DiscoveryFormDto>> HandleAsync()
    {
        // Obviously, this is a dummy query. Replace it with your own.
        // Write your query here
        var discovery = await DbContext.Discoveries
            .Where(u => u.Id == _id)
            .Select(u => new DiscoveryFormDto
            {
                Name = u.Name,
                Description = u.Description,
                MissionId = u.MissionId,
                Mission = u.Mission,
                Location = u.Location,
                DiscoveryType = u.DiscoveryType,
                DiscoveryTypeId = u.DiscoveryTypeId,

            })
            .FirstAsync();

        // Return the data
        var result = new RequestResult<DiscoveryFormDto> { Data = discovery };

        return result;
    }
}
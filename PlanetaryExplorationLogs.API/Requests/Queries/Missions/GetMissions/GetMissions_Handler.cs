using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using PlanetaryExplorationLogs.API.Data.Context;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Data.DTO;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Missions.GetMissions
{
    public class GetMissions_Handler : HandlerBase<List<MissionFormDto>>
	{
		public GetMissions_Handler(PlanetExplorationDbContext context)
			: base(context)
		{
		}

		public override async Task<RequestResult<List<MissionFormDto>>> HandleAsync()
		{
			var missionDtos = await DbContext.Missions
                .OrderByDescending(t => t.Date)
				.Select(t => new MissionFormDto
				{
					Name = t.Name,
					Description = t.Description,
					Date = t.Date,
					PlanetId = t.PlanetId,
					Planet = t.Planet,
					Discoveries = t.Discoveries
				})
                .ToListAsync();

            var result = new RequestResult<List<MissionFormDto>> { Data = missionDtos };

			return result;
		}
	}

}

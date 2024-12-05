using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Missions.UpdateMission;

public class UpdateMission_Command : RequestBase<int>
{
    private readonly MissionDto _mission;

    public UpdateMission_Command(PlanetExplorationDbContext context, MissionDto mission)
        : base(context)
    {
        _mission = mission;
    }

    // The validator is optional and can be removed if not needed
    public override IValidator Validator =>
        new UpdateMission_Validator(DbContext, _mission);

    // The handler is mandatory to have for every command
    public override IHandler<int> Handler =>
        new UpdateMission_Handler(DbContext, _mission);
}
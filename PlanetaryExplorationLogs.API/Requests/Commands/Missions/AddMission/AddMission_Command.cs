//// Paste these using statements at the top of the file and uncomment them
//using PlanetaryExplorationLogs.API.Data.Context;
//using PlanetaryExplorationLogs.API.Utility.Patterns;
//using System.Net;
//using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Missions.AddMission;

public class AddMission_Command : RequestBase<int>
{
    private readonly MissionFormDto _mission;

    public AddMission_Command (PlanetExplorationDbContext context, MissionFormDto mission)
        : base(context)
    {
        _mission = mission;
    }

    // The validator is optional and can be removed if not needed
    public override IValidator Validator =>
        new AddMission_Validator(DbContext, _mission);

    // The handler is mandatory to have for every command
    public override IHandler<int> Handler =>
        new AddMission_Handler (DbContext, _mission);
}


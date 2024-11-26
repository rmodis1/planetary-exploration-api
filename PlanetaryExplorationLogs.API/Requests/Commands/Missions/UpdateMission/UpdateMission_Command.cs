using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using System.Net;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Missions.UpdateMission;

public class UpdateMission_Command : RequestBase<int>
{
    private readonly Mission _mission;

    public UpdateMission_Command(PlanetExplorationDbContext context, Mission mission)
        : base(context)
    {
        _mission = mission;
    }

    // The validator is optional and can be removed if not needed
    public override IValidator Validator =>
        new classname_Validator(DbContext, _mission);

    // The handler is mandatory to have for every command
    public override IHandler<int> Handler =>
        new classname_Handler(DbContext, _mission);
}
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using System.Net;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

public class AddDiscoveryForMission_Command : RequestBase<int>
{
    private readonly DiscoveryFormDto _discovery;
    private readonly int _missionId;

    public AddDiscoveryForMission_Command(PlanetExplorationDbContext context, int missionId, DiscoveryFormDto discovery)
        : base(context)
    {
        _discovery = discovery;
        _missionId = missionId;
    }
    public override IValidator Validator =>
        new AddDiscoveryForMission_Validator(DbContext, _missionId, _discovery);

    // The handler is mandatory to have for every command
    public override IHandler<int> Handler =>
        new AddDiscoveryForMission_Handler(DbContext, _missionId, _discovery);
}
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Missions.CreateDiscoveryForMission;

public class AddDiscoveryForMission_Command : RequestBase<int>
{
    private readonly DiscoveryFormDto _discovery;

    public AddDiscoveryForMission_Command(PlanetExplorationDbContext context, DiscoveryFormDto discovery)
        : base(context)
    {
        _discovery = discovery;
    }
    public override IValidator Validator =>
        new AddDiscoveryForMission_Validator(DbContext, _discovery);

    // The handler is mandatory to have for every command
    public override IHandler<int> Handler =>
        new AddDiscoveryForMission_Handler(DbContext, _discovery);
}
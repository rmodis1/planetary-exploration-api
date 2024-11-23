//// Paste these using statements at the top of the file and uncomment them
//using PlanetaryExplorationLogs.API.Data.Context;
//using PlanetaryExplorationLogs.API.Utility.Patterns;
//using System.Net;
//using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

using PlanetaryExplorationLogs.API.Data.Context;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

public class AddMission_Command : RequestBase<int>
{
    private readonly int _someInputParameter;

    public AddMission_Command (PlanetExplorationDbContext context, int someInputParameter)
        : base(context)
    {
        _someInputParameter = someInputParameter;
    }


    // The validator is optional and can be removed if not needed
    public override IValidator Validator =>
        new AddMission_Validator(DbContext, _someInputParameter);

    // The handler is mandatory to have for every command
    public override IHandler<returntype> Handler =>
        new AddMission_Handler (DbContext, _someInputParameter);
}


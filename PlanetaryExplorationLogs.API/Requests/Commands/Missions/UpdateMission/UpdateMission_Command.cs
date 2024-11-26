using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using System.Net;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

public class UpdateMission_Command : RequestBase<ReturnType>
{
    private readonly int _someInputParameter;

    public UpdateMission_Command(PlanetExplorationDbContext context, int someInputParameter)
        : base(context)
    {
        _someInputParameter = someInputParameter;
    }

    // The validator is optional and can be removed if not needed
    public override IValidator Validator =>
        new classname_Validator(DbContext, _someInputParameter);

    // The handler is mandatory to have for every command
    public override IHandler<returntype> Handler =>
        new classname_Handler(DbContext, _someInputParameter);
}

// The validator class is responsible for validating things before the query is executed
using System.Net;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

public class AddMission_Validator : ValidatorBase
{
    private readonly int _someInputParameter;

    public AddMission_Validator(PlanetExplorationDbContext context, int someInputParameter)
        : base(context)
    {
        _someInputParameter = someInputParameter;
    }

    public override async Task<RequestResult> ValidateAsync()
    {
        await Task.CompletedTask;

        if (_someInputParameter < 0)
        {
            return await InvalidResultAsync(
                HttpStatusCode.BadRequest,
                "The input parameter needs to be greater than zero for some reason.");
        }

        return await ValidResultAsync();
    }
}
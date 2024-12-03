
using System.Net;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

public class GetPlanet_Validator : ValidatorBase
{
    private readonly int _planetId;

    public GetPlanet_Validator(PlanetExplorationDbContext context, int planetId)
        : base(context)
    {
        _planetId = planetId;
    }

    public override async Task<RequestResult> ValidateAsync()
    {
        // Obviously, this is dummy validation logic. Replace it with your own.
        await Task.CompletedTask;
        if (string.IsNullOrEmpty(_planetId.ToString()))
        {
            return await InvalidResultAsync(
                HttpStatusCode.BadRequest,
                "Need to have a value for the filter, apparently.");
        }

        // You can also check things in the database, if needed, such as checking if a record exists
        return await ValidResultAsync();
    }
}
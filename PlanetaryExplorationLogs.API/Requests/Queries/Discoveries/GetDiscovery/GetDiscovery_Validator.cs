// The validator class is responsible for validating things before the query is executed
using System.Net;
using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

public class GetDiscovery_Validator : ValidatorBase
{
    private readonly int _discoveryId;

    public GetDiscovery_Validator(PlanetExplorationDbContext context, int discoveryId)
        : base(context)
    {
        _discoveryId = discoveryId;
    }

    public override async Task<RequestResult> ValidateAsync()
    {
        // Check if the filter is provided
        if (_discoveryId == 0)
        {
            return await InvalidResultAsync(
                HttpStatusCode.BadRequest,
                "Must provide some value for the discovery id.");
        }

        // Assuming _id is the ID you want to check in the database
        var idExists = await DbContext.Discoveries.AnyAsync(d => d.Id == _discoveryId);

        // Return an error message if the ID does not exist
        if (!idExists)
        {
            return await InvalidResultAsync(
                HttpStatusCode.NotFound,
                $"The ID {_discoveryId} does not exist in the database.");
        }

        // You can also check things in the database, if needed, such as checking if a record exists
        return await ValidResultAsync();
    }
}
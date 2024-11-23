// The validator class is responsible for validating things before the query is executed
using System.Net;
using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

public class GetDiscovery_Validator : ValidatorBase
{
    private readonly int _id;

    public GetDiscovery_Validator(PlanetExplorationDbContext context, int id)
        : base(context)
    {
        _id = id;
    }

    public override async Task<RequestResult> ValidateAsync()
    {
        // Check if the filter is provided
        if (_id == 0)
        {
            return await InvalidResultAsync(
                HttpStatusCode.BadRequest,
                "Need to have a value for the filter, apparently.");
        }

        // Assuming _id is the ID you want to check in the database
        var idExists = await DbContext.Discoveries.AnyAsync(d => d.Id == _id);

        // Return an error message if the ID does not exist
        if (!idExists)
        {
            return await InvalidResultAsync(
                HttpStatusCode.NotFound,
                $"The ID {_id} does not exist in the database.");
        }

        // You can also check things in the database, if needed, such as checking if a record exists
        return await ValidResultAsync();
    }
}
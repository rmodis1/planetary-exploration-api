using System.Net;
using PlanetaryExplorationLogs.API.Data.DTO;

namespace PlanetaryExplorationLogs.API.Utility.Patterns
{
    public class RequestResult<T>
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; } = "";
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        public T? Data { get; set; }

        public static implicit operator RequestResult<T>(RequestResult<List<MissionFormDto>> v)
        {
            throw new NotImplementedException();
        }
    }

    public class RequestResult
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; } = "";
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
    }
}

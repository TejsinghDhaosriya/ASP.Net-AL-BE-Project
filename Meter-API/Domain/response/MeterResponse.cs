using System.Text.Json;

namespace Meter_API.Domain.response
{
    public class MeterResponse
    {
        public List<object> Data { get; }
        public string? Error { get; init; }
        public string? Warning { get; }
        public int? StatusCode { get; set; }

        public MeterResponse(List<object> data=null, string? error=null,string? warning=null,int? statusCode=null)
        {
            Data = data;
            Error = error;
            Warning = warning; 
            StatusCode = statusCode;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }

    }
}

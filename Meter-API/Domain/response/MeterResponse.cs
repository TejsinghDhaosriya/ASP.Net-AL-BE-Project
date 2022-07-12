using System.Collections;
using System.Text.Json;

namespace Meter_API.Domain.response
{
    public class MeterResponse
    {
        public object? Data { get; }
        public string? Error { get; init; }
        public string? Warning { get; }
        public int StatusCode { get; set; }

        public MeterResponse(object data=null, string? error=null,string? warning=null)
        {
            Data = data;
            Error = error;
            Warning = warning; 
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }

    }
}

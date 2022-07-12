using System.Collections;

namespace Meter_API.Domain.response
{
    public class MeterResponse
    {
        public object? Data { get; }
        public string? Error { get; }
        public string? Warning { get; }
        public MeterResponse(object data=null, string? error=null,string? warning=null)
        {
            Data = data;
            Error = error;
            Warning = warning; 
        }

    }
}

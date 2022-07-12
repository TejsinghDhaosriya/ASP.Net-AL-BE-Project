namespace Meter_API.Domain.requests;

public class QueryParameters
{
    public QueryParameters()
    {
        name = "";
        startDate = "";
        endDate = "";
        informationAt = "";
    }

    public string name { get; set; }

    public string startDate { get; set; }

    public string endDate { get; set; }

    public string informationAt { get; set; }

}
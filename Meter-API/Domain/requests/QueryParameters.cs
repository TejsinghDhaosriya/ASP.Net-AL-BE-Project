namespace Meter_API.Domain.requests;

public class QueryParameters
{
    public QueryParameters()
    {
        this.facilityName = "";
        this.startDate = "";
        this.endDate = "";
        this.informationAt = "";
    }

    public string facilityName { get; set; }

    public string startDate { get; set; }

    public string endDate { get; set; }

    public string informationAt { get; set; }

}
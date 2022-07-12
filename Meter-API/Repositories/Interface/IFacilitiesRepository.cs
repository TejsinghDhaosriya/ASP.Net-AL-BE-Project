using Meter_API.Models;

namespace Meter_API.Repositories.Interface
{
    public interface IFacilitiesRepository
    {
        IEnumerable<Facilities> FindAll();
    }
}

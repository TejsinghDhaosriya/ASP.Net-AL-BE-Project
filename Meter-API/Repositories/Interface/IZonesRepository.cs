using Meter_API.Models;

namespace Meter_API.Repositories.Interface
{
    public interface IZonesRepository
    {
        IEnumerable<Zones> FindAll();
        IEnumerable<Zones> FindAllByName(string qpName);
    }
}

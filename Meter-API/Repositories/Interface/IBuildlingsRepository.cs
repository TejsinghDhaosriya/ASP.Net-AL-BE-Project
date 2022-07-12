using Meter_API.Models;

namespace Meter_API.Repositories.Interface
{
    public interface IBuildingsRepository
    {
        IEnumerable<Buildings> FindAll();

        IEnumerable<Buildings> FindAllByName(string qpName);
    }
}

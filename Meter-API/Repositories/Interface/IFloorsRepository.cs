using Meter_API.Models;

namespace Meter_API.Repositories.Interface
{
    public interface IFloorsRepository
    {
        IEnumerable<Floors> FindAll();
        IEnumerable<Floors> FindAllByName(string qpName);
    }
}

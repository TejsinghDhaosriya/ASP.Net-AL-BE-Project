using Meter_API.Models;
using Meter_API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Meter_API.Repositories.Impl
{
    public class MetersRepository:IMetersRepository

    {
        private readonly MetersDbContext _context;

        public MetersRepository(MetersDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Meters> FindAll()
        {
            return _context.Meters;
        }

        public IEnumerable<Meters> FindAllByName(string name)
        {
            return _context.Meters.Where(m=>m.name == name);
        }
    }
}

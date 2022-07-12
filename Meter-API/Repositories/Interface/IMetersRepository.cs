﻿using Meter_API.Models;

namespace Meter_API.Repositories.Interface
{
    public interface IMetersRepository
    {
        IEnumerable<Meters> FindAll();
        IEnumerable<Meters> FindAllByName(string qpName);
    }
}
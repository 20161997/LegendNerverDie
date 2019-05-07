using System;

namespace LND.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        LegendNeverDieDbContext Init();
    }
}